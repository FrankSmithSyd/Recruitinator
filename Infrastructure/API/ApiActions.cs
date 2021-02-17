using System.Collections.Generic;
using Core.Entities;

namespace Infrastructure.API
{
    public interface ApiActions
    {
        public abstract IEnumerable<Candidate> GetCandidates();
        public abstract IEnumerable<Job> GetJobs();
    }
}