using System.Collections.Generic;
using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.Repositories;

namespace CVBuilder.Repository.Repositories
{
    public class SectionRepository<D,T> : ContextRepository, ISectionRepository<D,T> where D : class where T : class
    {
        public SectionRepository(CVBuilderDbContext context) : base (context)
        {
        }

        public int Create(D data)
        {
            T entity = Mapping.Mapper.Map<D,T>(data);
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }

        public void Update(D data, string keyProperty)
        {
            //T entity = this.GetByIdPrivate((int)data.GetType().GetProperty(keyProperty).GetValue(data));
            T dataToUpdate = Mapping.Mapper.Map<D,T>(data);
            _context.Set<T>().Update(dataToUpdate);
            _context.SaveChanges();
        }

        public int Delete(int id)
        {
            T entity = this.GetByIdPrivate(id);

            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                return _context.SaveChanges();
            }

            return 0;
        }

        private T GetByIdPrivate(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public D GetById(int id)
        {
            T entity = _context.Set<T>().Find(id);
            return Mapping.Mapper.Map<T,D>(entity);
        }

        public IEnumerable<D> GetAll(int curriculumId)
        {
            //IEnumerable<T> entityList = this.AllSectionResult(curriculumId);
            IEnumerable<T> entityList = _context.Set<T>().AsEnumerable().Where(x => (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId);
            var queryMapped = Mapping.Mapper.Map<IEnumerable<T>,List<D>>(entityList);
            return (IEnumerable<D>)queryMapped;
        }

        public IEnumerable<D> GetAllVisible(int curriculumId)
        {
            //IEnumerable<T> entityList = this.AllVisibleSectionResult(curriculumId);
            IEnumerable<T> entityList = _context.Set<T>().AsEnumerable().Where(x => (int)x.GetType().GetProperty("Id_Curriculum").GetValue(x) == curriculumId && (bool)x.GetType().GetProperty("IsVisible").GetValue(x));
            var queryMapped = Mapping.Mapper.Map<IEnumerable<T>,List<D>>(entityList);
            return (IEnumerable<D>)queryMapped;
        }

        public D GetLast()
        {
            T entity = _context.Set<T>().AsEnumerable().Last();
            return Mapping.Mapper.Map<T,D>(entity);
        }

        public void ToggleVisibility(string sectionIsVisible, int curriculumId)
        {
            Curriculum curriculum = _context.Curriculum.FirstOrDefault(c => c.CurriculumId == curriculumId);
            var propertyInfo = curriculum.GetType().GetProperty(sectionIsVisible);
            propertyInfo.SetValue(curriculum, !(bool)propertyInfo.GetValue(curriculum));
            _context.SaveChanges();
        }
    }
}