using System.Collections.Generic;
using CVBuilder.Core.DTOs;

namespace CVBuilder.Core.Services
{
    public interface ISectionService<T> where T : class
    {
        int Create(T dto);
        void Update(T dto);
        int Delete(int id);
        T GetById(int id);
        List<SummaryBlockDTO> GetAllBlocks(int curriculumId);
        SummaryBlockDTO GetSummaryBlock(int id);
    }
}