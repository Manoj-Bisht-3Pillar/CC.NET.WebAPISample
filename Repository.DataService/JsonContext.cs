using DomainObject.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DataService
{
    public class JsonContext
    {
        public string JsonFolderName { get; set; }
        
        public JsonContext()
        {
        }

        public JsonContext(string fileName)
        {
            JsonFolderName = System.Configuration.ConfigurationManager.AppSettings[fileName];
            if (!Directory.Exists(JsonFolderName))
            {
                Directory.CreateDirectory(JsonFolderName);
            }
        }
    }
}
