namespace CVBuilder.Repository.Repositories
{
    public class ContextRepository
    {
        protected readonly CVBuilderDbContext _context;

        public ContextRepository(CVBuilderDbContext context)
        {
            _context = context;
        }
    }
}