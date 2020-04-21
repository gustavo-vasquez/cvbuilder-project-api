using CVBuilder.Domain.Models;

namespace CVBuilder.Repository.Repositories.Interfaces
{
    public interface IPersonalDetailRepository
    {
        int Create(PersonalDetail data);
        int Update(PersonalDetail data, int curriculumId);
        PersonalDetail GetByCurriculumId(int curriculumId);
    }
}