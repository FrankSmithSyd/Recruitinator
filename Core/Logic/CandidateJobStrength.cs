using Core.Entities;

namespace Core.Logic
{
    public class CandidateJobStrength
    {
        public Candidate Candidate { get; }
        
        public Job Job { get; }

        public int Weight { get; }
        
        public CandidateJobStrength(Candidate candidate, Job job, int weight)
        {
            Candidate = candidate;
            Job = job;
            Weight = weight;
        }
    }
}