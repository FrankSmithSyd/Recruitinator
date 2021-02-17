using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure
{
    public interface IClientApiConsumer
    {
        public IEnumerable<Candidate> GetCandidates();
        public IEnumerable<Job> GetJobs();
    }
}