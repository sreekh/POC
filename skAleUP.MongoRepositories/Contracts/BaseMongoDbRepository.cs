using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skAleUP.MongoRepositories.Contracts
{
    public class BaseMongoDbRepository<T>
        where T : class
    {
        private MongoClient mongoClient;
        private IMongoDatabase mongoDB;
        public BaseMongoDbRepository(string databaseName)
        {
            mongoClient = new MongoClient();
            mongoDB = mongoClient.GetDatabase(databaseName);
        }

        private IMongoCollection<T> GetCollection()
        {
            if (mongoDB != null)
            {
                return mongoDB.GetCollection<T>(typeof(T).ToString());
            }
            else
                return null;
        }
        public T GetDocument(T document)
        {
            if (mongoDB != null)
            {
                return GetCollection().AsQueryable<T>().Where(d => d.Equals(document)).FirstOrDefault();
            }
            else
                return null;
        }
        public List<T> GetDocuments(List<T> documents)
        {
            if (mongoDB != null)
            {
                return (from dbDocs in GetCollection().AsQueryable<T>()
                       from inpDocs in documents
                       where dbDocs.Equals(inpDocs)
                       select dbDocs).ToList();
            }
            else
                return null;
        }
        public List<T> GetDocuments()
        {
            return (from dbDOcs in GetCollection().AsQueryable<T>()
                    select dbDOcs).ToList();
        }
        public T CreateDocument(T document)
        {
            GetCollection().InsertOne(document);
            return GetDocument(document);
        }
        public List<T> CreateDocuments(List<T> documents)
        {
            GetCollection().InsertMany(documents);
            return GetDocuments(documents);
        }

    }
}
