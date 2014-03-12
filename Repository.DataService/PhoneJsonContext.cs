using DomainObject.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataService
{
    public class PhoneJsonContext : JsonContext, IJsonContext
    {

        public IJsonSet<Phone> Phones { get; set; }
        public PhoneJsonContext():base("phoneDB")
        {
            //Still Need to inovate batter.
            //OnModalCreating += OnModalCreatingHandler;
            OnModalCreatingHandler();
        }

        public void OnModalCreatingHandler()
        {
            Phones = new JsonSet<Phone>();
        }
    }
}
