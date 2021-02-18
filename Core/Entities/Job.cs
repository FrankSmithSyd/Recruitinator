using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Job
    {
        public int Id { get; }
        public string Name { get; }
        public Company Company { get; }
        public IEnumerable<SkillTag> RequiredSkills { get; }
        
        public Job(int jobId, string name, string company, string skills)
        {
            Id = jobId;
            Name = name;
            Company = new Company(company);
            RequiredSkills = skills.Split(',').Select(x => new SkillTag(x));
        }

        public string GetAllSkillsAsCommaSeparatedString()
        {
            var skillTagNames = RequiredSkills.Select(x => x.Name);
            return string.Join(",", skillTagNames);
        }
    }
}