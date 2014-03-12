using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Repository.DataService
{
    public class JsonSet<TEntity> : IJsonSet<TEntity> where TEntity : class
    {
        private string _FileName = string.Empty;
        public bool IsIsolatedFile
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string FileName
        {
            get
            {
                _FileName = string.IsNullOrWhiteSpace(_FileName) ? typeof(TEntity).Name : _FileName;
                _FileName = _FileName.EndsWith(".json") ? _FileName : string.Format("{0}.json", _FileName);
                return _FileName;
            }
        }

        public JsonSet()
        {
            CreateFile(string.Empty);
        }


        public void CreateFile(string fileName)
        {
            _FileName = fileName;

            if (!File.Exists(FileName))
            {
                File.Create(FileName);
            }

        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            var rawData = File.ReadAllText(FileName);
            var data = JsonConvert.DeserializeObject<List<TEntity>>(rawData);
            return data;
        }

        public List<TEntity> ToList()
        {
            var data = GetEnumerable();
            return data != null ? GetEnumerable().ToList() : null;
        }

        public TEntity Add(TEntity entity)
        {
            var currentData = ToList();
            currentData.Add(entity);
            File.WriteAllText(FileName, JsonConvert.SerializeObject(currentData));
            return entity;
        }

        public bool Remove(TEntity entity)
        {
            var currentData = ToList();
            if (currentData == null)
            {
                return false;
            }
            currentData.Remove(entity);
            File.WriteAllText(FileName, JsonConvert.SerializeObject(currentData));
            return true;
        }
    }
}
