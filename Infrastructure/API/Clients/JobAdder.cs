using Infrastructure.API;
using RestSharp;

namespace Infrastructure.Clients
{
    public class JobAdder : IApiClient
    {
        public string ClientUri => "http://private-76432-jobadder1.apiary-mock.com/";
        public RestRequest GetCandidatesAction => new RestRequest("candidates", Method.GET);
        public RestRequest GetJobsAction => new RestRequest("jobs", Method.GET);
    }
}