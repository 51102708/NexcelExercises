namespace BusinessEnglish.Services
{
    using System.Collections.Generic;

    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}