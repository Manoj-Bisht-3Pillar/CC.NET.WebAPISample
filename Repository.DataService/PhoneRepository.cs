using System;
using System.Collections.Generic;
using DomainObject.Entity;
using Repository.Interface;

namespace Repository.DataService
{
    public class PhoneRepository : IPhoneRepository<Phone>
    {
        private List<Phone> phones = new List<Phone>();
        private int _nextAge = 0;
        private readonly IJsonContext phoneJsonContext;
        public PhoneRepository()
        {
            phoneJsonContext = new PhoneJsonContext();

            //Add(new Phone()
            //{
            //    Id = "motorola-xoom-with-wi-fi",
            //    Name = "Motorola XOOM\u2122 with Wi-Fi",
            //    Snippet = "The Next, Next Generation\r\n\r\nExperience the future with Motorola XOOM with Wi-Fi, the world's first tablet powered by Android 3.0 (Honeycomb).",
            //    ImageUrl = "img/phones/motorola-xoom-with-wi-fi.0.jpg"
            //});
        }

        public IEnumerable<Phone> GetAll()
        {
            var phones = phoneJsonContext.Phones.ToList();
            return phones;
        }

        public Phone Get(string id)
        {
            return phones.Find(p => p.Id == id);
        }

        public Phone Add(Phone item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Age = _nextAge++;
            phones.Add(item);
            return item;
        }

        public void Remove(string id)
        {
            phones.RemoveAll(p => p.Id == id);
        }

        public bool Update(Phone item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = phones.FindIndex(p => p.Age == item.Age);
            if (index == -1)
            {
                return false;
            }
            phones.RemoveAt(index);
            phones.Insert(index, item);
            return true;
        }
    }
}