using skAleUP.Common.Entities.WebUtils;
using skAleUP.MongoRepositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace skAleUP.Common.Services.Controllers
{
    public class WebLinksController : ApiController
    {
        BaseMongoDbRepository<WebLink> mongoDbWebLinksRepo;

        public WebLinksController()
        {
            mongoDbWebLinksRepo = new BaseMongoDbRepository<WebLink>("WebCrawlerDB");
        }

        // GET api/weblinks
        public IEnumerable<WebLink> Get()
        {
            return mongoDbWebLinksRepo.GetDocuments();
        }

        // GET api/weblinks/webLinkInstance
        public WebLink Get(WebLink webLink)
        {
            return mongoDbWebLinksRepo.GetDocument(webLink);
        }

        // POST api/weblinks
        public void Post([FromBody]WebLink webLink)
        {
            mongoDbWebLinksRepo.CreateDocument(webLink);
        }

        // PUT api/weblinks/guid
        public void Put(Guid id, [FromBody]WebLink webLink)
        {
            throw new NotImplementedException();
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
