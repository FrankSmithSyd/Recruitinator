using System.Collections.Generic;
using Core.Entities;
using NUnit.Framework;


namespace Core.Tests.SkillMatcher
{
    public class GetCandidateStrengthForJobShould
    {
        [Test]
        public void CalculdateWeightCorrectlyForFullyMatchingCandidateAndJobTags()
        {
            var job = new Job(1, "TEST JOB NAME", "TEST COMPANY", "SKILL 1, SKILL 2, SKILL 3");
            var candidate1 = new Candidate(1, "BOB", "SKILL 1, SKILL 2, SKILL 3");
            var expectedWeight = 3;    // 3 skills match between the job and candidate, giving us a weight of 3.
            
            var result = Logic.SkillMatcher.CalculateCandidateStrengthForJob(candidate1, job);

            Assert.AreEqual(expectedWeight, result.Weight);
        }

        [Test]
        public void CalculdateWeightCorrectlyForNoMatchingCandidateAndJobTags()
        {
            var job = new Job(1, "TEST JOB NAME", "TEST COMPANY", "SKILL 1, SKILL 2, SKILL 3");
            var candidate1 = new Candidate(1, "BOB", "SKILL 4, SKILL 5, SKILL 6");
            var expectedWeight = 0;    // 0 skills match between the job and candidate, giving us a weight of 0.
            
            var result = Logic.SkillMatcher.CalculateCandidateStrengthForJob(candidate1, job);

            Assert.AreEqual(candidate1, result.Candidate);
            Assert.AreEqual(job,result.Job);
            Assert.AreEqual(expectedWeight, result.Weight);
        }
        
        [Test]
        public void CalculdateWeightCorrectlyForSomeMatchingCandidateAndJobTags()
        {
            var job = new Job(1, "TEST JOB NAME", "TEST COMPANY", "SKILL 1, SKILL 2, SKILL 3");
            var candidate1 = new Candidate(1, "BOB", "SKILL 1, SKILL 2, SKILL 6, SKILL 7");
            var expectedWeight = 2;    // 2 skills match between the job and candidate, giving us a weight of 2.
            
            var result = Logic.SkillMatcher.CalculateCandidateStrengthForJob(candidate1, job);

            Assert.AreEqual(candidate1, result.Candidate);
            Assert.AreEqual(job,result.Job);
            Assert.AreEqual(expectedWeight, result.Weight);
        }
        
    }
}