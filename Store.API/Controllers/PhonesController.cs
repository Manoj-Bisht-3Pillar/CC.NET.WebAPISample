using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Store.API.Controllers
{
    public class PhonesController : ApiController
    {
        //GET: api/Phones
        public IHttpActionResult Get()
        {
            return Ok();
        }

        //GET: api/Phones/samsung-gem
        public IHttpActionResult Get(string id)
        {
            return Ok();
        }

        //DELETE: api/Phones/samsung-gem
        public IHttpActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
