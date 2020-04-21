using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        int Create(T data, int curriculumId);
        void Update(T data, string keyProperty);
        int Delete(int id);
        T GetById(int id);
        IQueryable<T> GetAll(System.Linq.Expressions.Expression<System.Func<T,bool>> predicate);
        IQueryable<T> GetAllVisible(System.Linq.Expressions.Expression<System.Func<T,bool>> predicate);
        T GetLast(System.Linq.Expressions.Expression<System.Func<T,int>> predicate);
        void ToggleVisibility(string sectionIsVisible, int curriculumId);
    }
}