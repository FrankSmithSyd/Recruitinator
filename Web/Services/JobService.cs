using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using Core.Logic;
using Infrastructure;

namespace Web.Services
{
    public interface IJobService : IService
    {
        public IEnumerable<Job> GetAllJobs();
        public Job GetJob(int id);
        public IEnumerable<CandidateJobStrength> GetCandidateJobMatches(int jobId);
    }
    
    public class JobService : BaseService, IJobService
    {
        public JobService(IRepository repository) : base(repository) {}
        
        public IEnumerable<Job> GetAllJobs() => Repository.GetJobs();

        public Job GetJob(int jobId) => Repository.GetJob(jobId);
        
        public IEnumerable<CandidateJobStrength> GetCandidateJobMatches(int jobId)
        {
            var job = GetJob(jobId);
            var candidates = Repository.GetCandidates();
            var result = SkillMatcher.GetJobStrengthForCandidates(job, candidates);

            return result;
        }
    }
}