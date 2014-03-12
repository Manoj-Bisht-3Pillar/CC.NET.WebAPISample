using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IJsonSet<TEntity> where TEntity : class
    {
        bool IsIsolatedFile { get; set; }
        string FileName {get;}
        void CreateFile(string fileName);
        IEnumerable<TEntity> GetEnumerable();
        List<TEntity> ToList();
        TEntity Add(TEntity entity);
        bool Remove(TEntity entity);


    }
}
