using System.Collections.Generic;

namespace Domain.IActions
{
    public interface IGeneralAction<T>
    {
        public List<T> ToList();
        public T FindById(string id);
        public string Add(T obj);
        public string Remove(T obj);
        public string Update(T obj);
    }
}
