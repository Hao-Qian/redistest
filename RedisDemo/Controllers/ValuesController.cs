using ServiceStack.Caching;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedisDemo.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            var lala = new List<string>
            {
                "1", "2", "3", "4", "5"
            };
            ICacheClientExtended cacheClient = new RedisClient("localhost");
            cacheClient.Add<IList<string>>("mykey", lala);
            var lala2 = cacheClient.Get<IList<string>>("mykey");
            return lala2;
    }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
