using System.Collections.Generic;

namespace Core.Entities
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Company Company { get; set; }
        public List<SkillTag> RequiredSkills { get; set; }
    }
}