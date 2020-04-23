using System.Collections.Generic;
using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class Repository<D,T> : ContextRepository, IRepository<D,T> where D : class where T : class
    {
        public Repository(CVBuilderDbContext context) : base (context)
        {
        }

        public int Create(D data, int curriculumId)
        {
            T entity = Mapping.Mapper.Map<D,T>(data);
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public void Update(D data, string keyProperty)
        {
            T entity = this.GetById((int)data.GetType().GetProperty(keyProperty).GetValue(data));

            if(entity != null)
            {
                entity = Mapping.Mapper.Map<D,T>(data);
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

        public IEnumerable<D> GetAll(int curriculumId)
        {
            IQueryable<T> entity = _context.Set<T>().Where(x => (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId);
            return Mapping.Mapper.Map<IQueryable<T>,IEnumerable<D>>(entity);
        }

        public IEnumerable<D> GetAllVisible(int curriculumId)
        {
            //Expression<System.Func<T,bool>> predicate
            IQueryable<T> entity = _context.Set<T>().Where(x =>
                (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId
                && (bool)x.GetType().GetProperty("IsVisible").GetValue(x));

            return Mapping.Mapper.Map<IQueryable<T>,IEnumerable<D>>(entity);
        }

        public D GetLast()
        {
            T entity = _context.Set<T>().OrderByDescending(x => (int)x.GetType().GetProperty("StudyId").GetValue(x)).First();
            return Mapping.Mapper.Map<T,D>(entity);
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