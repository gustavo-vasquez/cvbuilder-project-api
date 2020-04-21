using System.Linq;
using CVBuilder.Domain.Models;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Repository.Repositories.Implementations
{
    public class CurriculumRepository : ContextRepository, ICurriculumRepository
    {
        /* private readonly CVBuilderDbContext _context;

        public CurriculumRepository(CVBuilderDbContext context)
        {
            _context = context;
        } */
        public CurriculumRepository(CVBuilderDbContext context) : base (context)
        {
        }

        public int Create(int userId)
        {
            //ObjectParameter id_curriculum_inserted = new ObjectParameter("id_curriculum_inserted", typeof(int));
            //_context.usp_Curriculum_Create(userId, id_curriculum_inserted);

            return 1;
        }

        public int GetByUserId(int userId)
        {
            return _context.Curriculum.SingleOrDefault(c => c.Id_User == userId).CurriculumId;
        }

        public Curriculum GetById(int curriculumId)
        {
            return _context.Curriculum.SingleOrDefault(c => c.CurriculumId == curriculumId);
        }
    }
}