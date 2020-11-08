using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Models
{
    public interface IGeneralAction<T>
    {
        public List<T> ToList();
        public T FindById(string id);
        public void Add(T obj);
        public void Remove(T obj);
        public void Update(T obj);
    }
}
