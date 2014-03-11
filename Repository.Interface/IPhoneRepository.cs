using System.Collections.Generic;

namespace Repository.Interface
{
    public interface IPhoneRepository<T>
    {
        IEnumerable<T> GetAll();

        T Get(string id);

        T Add(T item);

        void Remove(string id);

        bool Update(T item);
    }
}