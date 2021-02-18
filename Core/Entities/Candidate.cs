using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Core.Entities
{
    public class Candidate
    {
        public int CandidateId { get; }
        public string Name { get; }
        public IEnumerable<SkillTag> SkillTags { get; }
        
        [JsonConstructor]
        public Candidate(int candidateId, string name, string skillTags)
        {
            CandidateId = candidateId;
            Name = name;
            SkillTags = skillTags.Split(',').Select(x => new SkillTag(x));
        }
        
        public Candidate(int candidateId, string name, IEnumerable<SkillTag> skillTags)
        {
            CandidateId = candidateId;
            Name = name;
            SkillTags = skillTags;
        }
        
        public string GetAllSkillsAsCommaSeparatedString()
        {
            var skillTagNames = SkillTags.Select(x => x.Name);
            return string.Join(",", skillTagNames);
        }
    }
}