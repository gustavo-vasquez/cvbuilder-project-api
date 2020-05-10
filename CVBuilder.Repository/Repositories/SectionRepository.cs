using System.Collections.Generic;
using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Automapper;
using CVBuilder.Core.Repositories;
using System;
using CVBuilder.Core.DTOs;
using System.Linq.Expressions;

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
            T entity = this.GetByIdPrivate((int)data.GetType().GetProperty(keyProperty).GetValue(data));

            if(entity != null)
            {
                entity = Mapping.Mapper.Map<D,T>(data);
                _context.SaveChanges();
            }
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
            IEnumerable<T> entityList = SectionQueryResult(curriculumId);
            var queryMapped = Mapping.Mapper.Map<IEnumerable<T>,List<D>>(entityList);
            return (IEnumerable<D>)queryMapped;
        }

        private IEnumerable<T> SectionQueryResult(int curriculumId)
        {
            var TClassName = typeof(T).FullName;

            if(TClassName == typeof(Study).FullName)
                return (IEnumerable<T>)_context.Studies.Where(x => x.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(WorkExperience).FullName)
                return (IEnumerable<T>)_context.WorkExperiences.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(Certificate).FullName)
                return (IEnumerable<T>)_context.Certificates.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(Language).FullName)
                return (IEnumerable<T>)_context.Languages.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(Skill).FullName)
                return (IEnumerable<T>)_context.Skills.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(Interest).FullName)
                return (IEnumerable<T>)_context.Interests.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(PersonalReference).FullName)
                return (IEnumerable<T>)_context.PersonalReferences.Where(s => s.Id_Curriculum == curriculumId);
            else if(TClassName == typeof(CustomSection).FullName)
                return (IEnumerable<T>)_context.CustomSections.Where(s => s.Id_Curriculum == curriculumId);

            throw new Exception("La sección indicada no existe.");
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