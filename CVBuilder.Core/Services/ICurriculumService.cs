using CVBuilder.Core.DTOs;
using CVBuilder.Core.Helpers;

namespace CVBuilder.Core.Services
{
    public interface ICurriculumService
    {
        int Create(int userId);
        int GetByUserId(int userId);
        BuildDTO GetContent(string email);
        dynamic GetSectionFormData(SectionNames section, int id);
        SummaryBlockDTO GetSectionBlock(SectionNames section, int id);
        void AddOrUpdateSectionBlock<T>(T dto, FormMode mode, SectionNames section);
        void DeleteSectionBlock(SectionNames section, int id);
        void ToggleSectionVisibility(SectionNames section, string email);
        FinishedDTO GetContentReady(int userId, int curriculumId);
    }
}