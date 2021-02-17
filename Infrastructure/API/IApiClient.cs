using RestSharp;

namespace Infrastructure.API
{
    public interface IApiClient
    {
        public string ClientUri { get; }
        public RestRequest GetCandidatesAction { get; }
        public RestRequest GetJobsAction { get; }
        
    }
}