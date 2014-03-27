using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using DomainObject.Entity;
using Microsoft.Ajax.Utilities;
using Repository.DataService;
using Repository.Interface;

namespace Store.API.Controllers
{
    public class PhonesRpcController : ApiController
    {
        static readonly IPhoneRepository<Phone> repository = new PhoneRepository();

        public PhonesRpcController()
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

        #region RpcStyle Routing Variations by Action Name

        //GET: rpc/PhonesRpc/PhoneList
        [HttpGet]
        //[AcceptVerbs("Get")]
        public HttpResponseMessage PhoneList()
        {
            var items = repository.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, items.ToList());
        }

        //GET: rpc/PhonesRpc/FecthPhoneById/samsung-gem
        [HttpGet]
        public HttpResponseMessage FecthPhoneById(string id)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    string.Format("Phone with id = {0} not found.", id));
            }
            return Request.CreateResponse(HttpStatusCode.OK, item);
        }

        //PUT: rpc/PhonesRpc/PhoneUpdate/samsung-gem
        [HttpPut]
        public HttpResponseMessage PhoneUpdate(string id, Phone phone)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                     string.Format("Phone with id = {0} not found.", id));
            }
            else
            {
                item.Age = phone.Age;
                var result = repository.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
        }

        //POST: rpc/PhonesRpc/Save
        [HttpPost]
        public HttpResponseMessage Save(Phone phone)
        {
            var result = repository.Add(phone);
            var response = Request.CreateResponse(HttpStatusCode.Created, result);

            var uri = Url.Link("RpcStyleApi", new { id = result.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        //DELETE: rpc/PhonesRpc/PhoneDeleteById/samsung-gem
        [HttpDelete]
        public HttpResponseMessage PhoneDeleteById(string id)
        {
            repository.Remove(id);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }


        //Add Microsoft ASP.NET Web API OData nuget Package for partial entity updates
        //PATCH : /rpc/PhonesRpc/PhonePartial/samsung-gem
        //Body: {"age":"2"}
        [HttpPatch]
        public HttpResponseMessage PhonePartial(string id, Phone phone)
        {
            var item = repository.Get(id);
            if (item == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                     string.Format("Phone with id = {0} not found.", id));
            }
            else
            {
               // phone.Patch(item);

                var result = repository.Update(item);
                return Request.CreateResponse(HttpStatusCode.OK, item);
            }
        }

        #endregion
    }
}