using System.Collections.Generic;
using Core.Entities;
using Infrastructure;

namespace Web.Services
{
    public interface IJobService : IService
    {
        IEnumerable<Job> GetAllJobs();
    }
    
    public class JobService : BaseService, IJobService
    {
        public JobService(IRepository repository) : base(repository) {}
        
        public IEnumerable<Job> GetAllJobs() => Repository.GetJobs();
    }
}