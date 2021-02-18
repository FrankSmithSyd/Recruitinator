using System.Collections.Generic;
using Core.Entities;
using NUnit.Framework;

namespace Core.Tests.SkillMatcher
{
    public class GetSkillsMatchingCandidate
    {
        [Test]
        public void MatchSkillsWithCandidate()
        {
            var skills = new List<SkillTag>()
            {
                new SkillTag("TEST SKILL 1"),
                new SkillTag("TEST SKILL 2"),
            };
            var candidate = new Candidate(1, "C1", skills);
            
            var result = Logic.SkillMatcher.GetSkillsMatchingCandidateSkills(candidate, skills);
            
            Assert.AreEqual(skills, result);
        }
        
        [Test]
        public void NotMatchNonApplicableSkillsWithCandidate()
        {
            var uniqueCandidateSkill = new SkillTag("C1 SKILL");
            var candidate = new Candidate(1, "C1", new List<SkillTag> { uniqueCandidateSkill });
            var nonApplicableSkills = new List<SkillTag>()
            {
                new SkillTag("TEST SKILL 1"),
                new SkillTag("TEST SKILL 2"),
            };

            var result = Logic.SkillMatcher.GetSkillsMatchingCandidateSkills(candidate, nonApplicableSkills);
            
            Assert.IsEmpty(result);
        }
        
        
        
        
    }
}