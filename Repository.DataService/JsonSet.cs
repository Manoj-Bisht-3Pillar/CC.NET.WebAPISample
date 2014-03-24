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
                return string.Format("{0}{1}.json", _FileName, typeof(TEntity).Name); ;
            }
        }

        public JsonSet(string jsonFilePath)
        {
            CreateFile(jsonFilePath);
        }


        public void CreateFile(string fileName)
        {
            _FileName = fileName;

            if (!File.Exists(FileName))
            {
                using (var file = File.Create(FileName))
                {

                }
            }

        }

        public IEnumerable<TEntity> GetEnumerable()
        {
            var rawData = File.ReadAllText(FileName);
            var data = JsonConvert.DeserializeObject<List<TEntity>>(rawData)??new List<TEntity>();
            return data;
        }

        public List<TEntity> ToList()
        {
            var data = GetEnumerable();
            return data != null ? data.ToList() : null;
        }

        public TEntity Add(TEntity entity)
        {
            var currentData = ToList();
            currentData.Add(entity);
            UpdateFile(currentData);
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
          return UpdateFile(currentData);
        }

        private bool UpdateFile(List<TEntity> data)
        {
            File.WriteAllText(FileName, JsonConvert.SerializeObject(data));
            return true;
        }
    }
}
