using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.Logic
{
    public static class SkillMatcher
    {
        public static ICollection<Candidate> GetCandidatesMatchingSkill(SkillTag skill, IEnumerable<Candidate> candidates)
        {
            var matchingCandidates = candidates.Where(candidate => candidate.SkillTags.Contains(skill)).ToList();

            return matchingCandidates;
        }

        public static ICollection<SkillTag> GetSkillsMatchingCandidateSkills(Candidate candidate, IEnumerable<SkillTag> applicableSkills)
        {
            var matchingSkills =
                from candidateSkill in candidate.SkillTags
                join skill in applicableSkills
                    on candidateSkill.Name equals skill.Name
                select skill;

            return matchingSkills.ToList();
        }

            
        
    }
}