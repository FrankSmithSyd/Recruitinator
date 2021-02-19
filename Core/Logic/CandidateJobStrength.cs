using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.Logic
{
    public class CandidateJobStrength
    {
        public Candidate Candidate { get; }
        
        public Job Job { get; }
        
        public IEnumerable<SkillTag> MatchedSkills { get; }

        public int Weight { get; }
        
        public CandidateJobStrength(Candidate candidate, Job job, int weight, IEnumerable<SkillTag> matchedSkillTags)
        {
            Candidate = candidate;
            Job = job;
            Weight = weight;
            MatchedSkills = matchedSkillTags;
        }
        
        public string GetMatchedSkillsAsCommaSeparatedString()
        {
            var skillTagNames = MatchedSkills.Select(x => x.Name);
            return string.Join(",", skillTagNames);
        }
    }
}