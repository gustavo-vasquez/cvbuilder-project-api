using CVBuilder.Core.DTOs;
using CVBuilder.Core.Helpers;

namespace CVBuilder.Core.Services
{
    public interface ICurriculumService
    {
        int Create(int userId);
        int GetByUserId(int userId);
        BuildDTO GetContent(string email);
        FinishedDTO GetCurriculumContent(int userId, int curriculumId);
        SummaryBlockDTO GetSectionBlock(SectionNames section, int id);
        void AddOrUpdateSectionBlock<T>(T dto, FormMode mode, SectionNames section);
        void DeleteSectionBlock(SectionNames section, int id);
        void ToggleSectionVisibility(SectionNames section, string email);
    }
}