using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthenticationTest.Controllers
{

    ///this might be a problem
    //[Authorize(Users = "DESKTOP-H8546LJ//CREATOR OWNER")]
    public class ValuesController : ApiController
    {

        
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "binary", "thistle" };
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
