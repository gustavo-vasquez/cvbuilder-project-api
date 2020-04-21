using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class Repository<T> : ContextRepository, IRepository<T> where T : class
    {
        /* private readonly CVBuilderDbContext _context;

        public StudiesRepository(CVBuilderDbContext context)
        {
            _context = context;
        } */
        public Repository(CVBuilderDbContext context) : base (context)
        {
        }

        public int Create(T data, int curriculumId)
        {
            _context.Set<T>().Add(data);
            return _context.SaveChanges();
        }

        public void Update(T data, string keyProperty)
        {
            T entity = this.GetById((int)data.GetType().GetProperty(keyProperty).GetValue(data));

            if(entity != null)
            {
                entity = data;
                _context.SaveChanges();
            }
        }

        public int Delete(int id)
        {
            T entity = this.GetById(id);

            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChanges();
            }

            return 0;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> GetAll(System.Linq.Expressions.Expression<System.Func<T,bool>> predicate)
        {
            //return _context.Set<TEntity>().Where(x => (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId);
            return _context.Set<T>().Where(predicate);
        }
        public void lol(Study asd, int curriculumId)
        {
            this.GetAll(Study => asd.Id_Curriculum == curriculumId);
        }

        public IQueryable<T> GetAllVisible(System.Linq.Expressions.Expression<System.Func<T,bool>> predicate)
        {
            /* return _context.Set<TEntity>().Where(x =>
                (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId
                && (bool)x.GetType().GetProperty("IsVisible").GetValue(x)); */
            return _context.Set<T>().Where(predicate);
        }

        public T GetLast(System.Linq.Expressions.Expression<System.Func<T,int>> predicate)
        {
            //return _context.Set<TEntity>().OrderByDescending(x => (int)x.GetType().GetProperty("StudyId").GetValue(x)).First();
            return _context.Set<T>().OrderByDescending(predicate).First();
        }

        public void ToggleVisibility(string sectionIsVisible, int curriculumId)
        {
            Curriculum curriculum = _context.Curriculum.SingleOrDefault(c => c.CurriculumId == curriculumId);
            var propertyInfo = curriculum.GetType().GetProperty(sectionIsVisible);
            propertyInfo.SetValue(curriculum, !(bool)propertyInfo.GetValue(curriculum));
            //curriculum.StudiesIsVisible = !curriculum.StudiesIsVisible;
            _context.SaveChanges();
        }
    }
}