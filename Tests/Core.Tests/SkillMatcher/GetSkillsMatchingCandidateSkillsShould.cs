using System.Collections.Generic;
using Core.Entities;
using NUnit.Framework;

namespace Core.Tests.SkillMatcher
{
    public class GetSkillsMatchingCandidateSkillsShould
    {
        [Test]
        public void MatchCandidateWithApplicableSkill()
        {
            var skill = new SkillTag("TEST SKILL");
            var candidate = new Candidate(1, "C1", new List<SkillTag>() { skill });
            var candidates = new List<Candidate>() {candidate};

            var result = Logic.SkillMatcher.GetCandidatesMatchingSkill(skill, candidates);
            
            Assert.True(result.Contains(candidate));
        }
        
        [Test]
        public void NotMatchCandidateWithoutApplicableSkill()
        {
            var skill = new SkillTag("TEST SKILL");
            var candidate = new Candidate(1, "C1", new List<SkillTag>());
            var candidates = new List<Candidate>() {candidate};

            var result = Logic.SkillMatcher.GetCandidatesMatchingSkill(skill, candidates);
            
            Assert.False(result.Contains(candidate));
        }
    }
}