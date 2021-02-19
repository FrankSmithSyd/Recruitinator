using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure
{
    public interface IRepository
    {
        public IEnumerable<Candidate> GetCandidates();
        public IEnumerable<Job> GetJobs();
        public Job GetJob(int jobId);
    }
}