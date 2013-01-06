using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bookwarm.Models;
using Bookwarm.Services;

namespace Bookwarm.Controllers
{
    public class PageController : ApiController
    {
        private readonly IReadingRepository _repository;

        public PageController(IReadingRepository repository)
        {
            _repository = repository;
        }

        // GET api/page
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/page/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/page
        public void Post(Reading reading)
        {
        }

        // PUT api/page/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/page/5
        public void Delete(int id)
        {
        }
    }
}
