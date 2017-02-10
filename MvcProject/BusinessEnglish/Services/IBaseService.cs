namespace BusinessEnglish.Services
{
    using System.Collections.Generic;

    public interface IBaseService
    {
        IEnumerable<object> GetAll();

        object Get(int id);

        void Create(object obj);

        void Update(object obj);

        void Delete(int id);
    }
}