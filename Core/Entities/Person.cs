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
            SkillTags = skillTags.Split(',').Select(x => new SkillTag(x));    //TODO: Maybe only get distinct skills, I'm noticing some duplicates in the dataset.
        }
        
        public string GetAllSkillsAsCommaSeparatedString()
        {
            var skillTagNames = SkillTags.Select(x => x.Name);
            return string.Join(",", skillTagNames);
        }
    }
}