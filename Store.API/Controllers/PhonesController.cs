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

        public PhonesController()
        {
            repository.Add(new Phone()
            {
                Id = "samsung-gem",
                Age = 30,
                Name = "Samsung"
            });
            repository.Add(new Phone()
            {
                Id = "Nokia-gem",
                Age = 40,
                Name = "Nokia"
            }); 
            repository.Add(new Phone()
            {
                Id = "micromax-gem",
                Age = 10,
                Name = "Micromax"
            });
        }

        #region Default Routing with Action Names verb

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

        //PUT: api/Phones/samsung-gem
        //Request Body:
        //{'age':30,'Name':'Samsung-Gem'}
        public IHttpActionResult Put(string id,Phone phone)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                //var err = new HttpError(string.Format("Phone with id = {0} not found.", id));
                return NotFound();
            }
            else
            {
                item.Age = phone.Age;
                var result = repository.Update(item);
                return Ok(result);
            }
        }

        //POST: api/Phones/
        public IHttpActionResult Post(Phone phone)
        {
            var result = repository.Add(phone);
            return Ok(result);
        }

        //DELETE: api/Phones/samsung-gem
        public IHttpActionResult Delete(string id)
        {
            repository.Remove(id);
            return Ok();
        }

        #endregion

        #region Default Routing 2 with ActionNames suffix
        ////GET: api/Phones
        //public IHttpActionResult GetPhones()
        //{
        //    var items = repository.GetAll();
        //    return Ok(items);
        //}

        ////GET: api/Phones/samsung-gem
        //public IHttpActionResult GetPhones(string id)
        //{
        //    var item = repository.Get(id);
        //    if (item == null)
        //    {
        //        //var err = new HttpError(string.Format("Phone with id = {0} not found.", id));
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(item);
        //    }
        //}

        ////DELETE: api/Phones/samsung-gem
        //public IHttpActionResult DeletePhone(string id)
        //{
        //    return Ok();
        //}

        #endregion

    }
}
