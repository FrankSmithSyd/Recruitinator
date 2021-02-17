using System.Collections.Generic;
using Core.Entities;
using Infrastructure;

namespace Web.Services
{
    public interface ICandidateService : IService
    {
        IEnumerable<Candidate> GetAllCandidates();
    }

    public class CandidateService : BaseService, ICandidateService
    {
        public CandidateService(IRepository repository) : base(repository) {}

        public IEnumerable<Candidate> GetAllCandidates() => Repository.GetCandidates();
    }
}