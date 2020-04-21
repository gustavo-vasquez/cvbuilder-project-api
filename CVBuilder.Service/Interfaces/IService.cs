using System.Collections.Generic;
using CVBuilder.Service.DTOs;

namespace CVBuilder.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        int Create(T data, int curriculumId);
        void Update(T data, int curriculumId);
        int Delete(int id);
        T GetById(int id);
        List<SummaryBlockDTO> GetAllBlocks(int curriculumId);
        SummaryBlockDTO GetSummaryBlock(int id);
    }
}