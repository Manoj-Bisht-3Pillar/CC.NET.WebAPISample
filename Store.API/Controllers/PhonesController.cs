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

        //GET: api/Phones/1
        public IHttpActionResult Get(string id)
        {
            return Ok();
        }
    }
}
