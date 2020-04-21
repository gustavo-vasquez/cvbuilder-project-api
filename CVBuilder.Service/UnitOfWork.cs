using CVBuilder.Repository.Repositories.Implementations;
using CVBuilder.Repository.Repositories.Interfaces;

namespace CVBuilder.Service
{
    public class UnitOfWork
    {
        protected readonly IUnitOfWorkRepository _UnitOfWork;

        public UnitOfWork(IUnitOfWorkRepository unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
    }
}