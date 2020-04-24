using System.Collections.Generic;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IRepository<D,T> where D : class where T : class
    {
        int Create(D data);
        void Update(D data, string keyProperty);
        int Delete(int id);
        D GetById(int id);
        IEnumerable<D> GetAll(int curriculumId);
        IEnumerable<D> GetAllVisible(int curriculumId);
        D GetLast();
        void ToggleVisibility(string sectionIsVisible, int curriculumId);
    }
}