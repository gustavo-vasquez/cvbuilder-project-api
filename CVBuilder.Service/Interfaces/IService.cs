using System.Collections.Generic;
using CVBuilder.Repository.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        int Create(T dto);
        void Update(T dto);
        int Delete(int id);
        T GetById(int id);
        List<SummaryBlockDTO> GetAllBlocks(int curriculumId);
        SummaryBlockDTO GetSummaryBlock(int id);
    }
}