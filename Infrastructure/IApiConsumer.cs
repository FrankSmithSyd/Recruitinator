using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure
{
    public interface IApiConsumer
    {
        public abstract IEnumerable<Candidate> GetCandidates();
        public abstract IEnumerable<Job> GetJobs();
    }
}