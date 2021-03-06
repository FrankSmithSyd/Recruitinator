﻿using System.Collections.Generic;
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

        public static ICollection<Candidate> GetCandidatesMatchingAnySkills(IList<Candidate> candidates, IList<SkillTag> applicableSkills)
        {
            var matchingCandidates = new List<Candidate>();    // TODO FRANK: there's DEFINATELY a faster way to do this than a O(n^2) loop on all skills with linq and some smart joining, but running out of time. 
            
            foreach(var skill in applicableSkills)
                matchingCandidates.AddRange(GetCandidatesMatchingSkill(skill, candidates));

            return matchingCandidates;
        } 
        
        
        
        public static IEnumerable<CandidateJobStrength> GetJobStrengthForCandidates(Job job, IEnumerable<Candidate> candidates)
        {
            var candidateStrengths = 
                candidates
                    .Select(candidate => CalculateCandidateStrengthForJob(candidate, job))
                    .Where(x => x.Weight > 0)
                    .OrderByDescending(x => x.Weight)
                    .ToList();

            return candidateStrengths;
        }
        
        public static CandidateJobStrength CalculateCandidateStrengthForJob(Candidate candidate, Job job)
        {
            var matchingTags = 
            (
                from candidateSkill in candidate.SkillTags
                join jobSkill in job.RequiredSkills
                    on candidateSkill.Name equals jobSkill.Name
                select candidateSkill
            ).ToList();

            var candidateJobStrength = new CandidateJobStrength(candidate, job, matchingTags.Count(), matchingTags);
            
            return candidateJobStrength;
        }


        
    }
}