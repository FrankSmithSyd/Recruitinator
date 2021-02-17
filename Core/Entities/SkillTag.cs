namespace Core.Entities
{
    public class SkillTag
    {
        public string Name { get; set; }

        public SkillTag(string tagName)
        {
            Name = tagName;
        }
    }
}