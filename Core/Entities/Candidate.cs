using System.Collections.Generic;

namespace Core.Entities
{
    public class Candidate : Person
    {
        public Candidate(int candidateId, string name, string skillTags) : base(candidateId, name, skillTags) {}
        public Candidate(int candidateId, string name, IEnumerable<SkillTag> skillTags) : base(candidateId, name, skillTags) {}
    }
}