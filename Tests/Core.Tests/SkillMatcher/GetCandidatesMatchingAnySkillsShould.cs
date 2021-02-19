using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NUnit.Framework;

namespace Core.Tests.SkillMatcher
{
    public class GetCandidatesMatchingAnySkillsShould
    {
        [Test]
        public void MatchAnyCandidatesWithAtLeast1ApplicableSkill()
        {
            var skills = new List<SkillTag>
            {
                new SkillTag("TEST SKILL 1"),
                new SkillTag("TEST SKILL 2"),
            };
            var candidate = new Candidate(1, "C1", new List<SkillTag>() { skills.First() });
            var candidates = new List<Candidate>()
            {
                candidate, 
                new Candidate(2, "c2", new List<SkillTag>()),
                new Candidate(3, "c3", new List<SkillTag>())
            };

            var result = Logic.SkillMatcher.GetCandidatesMatchingAnySkills(candidates, skills);
            
            Assert.True(result.Contains(candidate));
        }
        
        [Test]
        public void MatchOnlyCandidatesWithApplicableSkills()
        {
            var skills = new List<SkillTag>
            {
                new SkillTag("TEST SKILL 1"),
                new SkillTag("TEST SKILL 2"),
            };
            var candidate1 = new Candidate(1, "C1", new List<SkillTag>() { skills.First() });
            var badCandidate2 = new Candidate(2, "c2", new List<SkillTag>());
            
            var candidates = new List<Candidate>()
            {
                candidate1,
                badCandidate2
            };

            var result = Logic.SkillMatcher.GetCandidatesMatchingAnySkills(candidates, skills);
            
            Assert.True(result.Contains(candidate1));
            Assert.False(result.Contains(badCandidate2));
        }
        
        [Test]
        public void NotMatchCandidatesWithoutAtLeast1ApplicableSkill()
        {
            var nonApplicableSkills = new List<SkillTag>
            {
                new SkillTag("TEST SKILL 1"),
                new SkillTag("TEST SKILL 2"),
            };
            var candidates = new List<Candidate>()
            {
                new Candidate(2, "c2", new List<SkillTag>()),
                new Candidate(3, "c3", new List<SkillTag>())
            };

            var result = Logic.SkillMatcher.GetCandidatesMatchingAnySkills(candidates, nonApplicableSkills);

            Assert.IsEmpty(result);
        }
    }
}