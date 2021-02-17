using RestSharp;

namespace Infrastructure.API
{
    public interface IApiClient
    {
        public string clientUri { get; }
        public RestRequest GetCandidatesAction { get; }
        public RestRequest GetJobsAction { get; }
        
    }
}