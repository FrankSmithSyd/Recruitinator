using System.Collections.Generic;
using System.Linq;

namespace Core.Entities
{
    public class Person
    {
        private int Id { get; }
        private string Name { get; }
        private IEnumerable<SkillTag> SkillTags { get; }

        protected Person(int id, string name, string skillTags)
        {
            Id = id;
            Name = name;
            SkillTags = skillTags.Split(',').Select(x => new SkillTag(x));    //TODO: Maybe only get distinct skills, I'm noticing some duplicates in the dataset.

        }
    }
}