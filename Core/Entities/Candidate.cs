namespace Core.Entities
{
    public class Candidate : Person
    {
        public Candidate(int candidateId, string name, string skillTags) : base(candidateId, name, skillTags)
        {
        }
    }
}