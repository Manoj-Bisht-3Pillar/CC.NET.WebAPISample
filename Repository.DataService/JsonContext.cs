using DomainObject.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataService
{
    public class JsonContext
    {
        public event Action OnModalCreating;
        public JsonContext()
        {
        }

        public JsonContext(string fileName)
        {
            if (OnModalCreating != null)
            {
                OnModalCreating();
            }
        }
    }
}
