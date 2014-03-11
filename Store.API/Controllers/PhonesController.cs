using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DomainObject.Entity;
using Repository.Interface;
using Repository.DataService;

namespace Store.API.Controllers
{
    public class PhonesController : ApiController
    {

        static readonly IPhoneRepository<Phone> repository = new PhoneRepository(); 

        //GET: api/Phones
        public IHttpActionResult Get()
        {
            var items = repository.GetAll();            
            return Ok(items);
        }

        //GET: api/Phones/samsung-gem
        public IHttpActionResult Get(string id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                //var err = new HttpError(string.Format("Phone with id = {0} not found.", id));
                return NotFound();                 
            }
            else
            {
                return Ok(item);
            }
        }

        //DELETE: api/Phones/samsung-gem
        public IHttpActionResult Delete(string id)
        {
            return Ok();
        }
    }
}
