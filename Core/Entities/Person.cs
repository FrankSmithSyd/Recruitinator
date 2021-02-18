using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Person
    {
        public int Id { get; }
        public string Name { get; }
        public IEnumerable<SkillTag> SkillTags { get; }

        protected Person(int id, string name, string skillTags)
        {
            Id = id;
            Name = name;
            SkillTags = skillTags.Split(',').Select(x => new SkillTag(x));
        }
        
        protected Person(int id, string name, IEnumerable<SkillTag> skillTags)
        {
            Id = id;
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