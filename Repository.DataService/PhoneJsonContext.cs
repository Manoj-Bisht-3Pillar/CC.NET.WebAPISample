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
            LoadTables();
        }

        public void LoadTables()
        {
            Phones = new JsonSet<Phone>(JsonFolderName);
        }
    }
}
