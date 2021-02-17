using Infrastructure;

namespace Web.Services
{
    public class BaseService
    {
        protected readonly IRepository Repository;

        public BaseService(IRepository repository)
        {
            Repository = repository;
        }
    }
}