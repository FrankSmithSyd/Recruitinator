using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.API;
using Infrastructure.Clients;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Infrastructure
{
    public class ClientApiConsumer : IClientApiConsumer
    {
        private IApiClient _api;
        private IRestClient _restClient; 

        public ClientApiConsumer(IApiClient api)
        {
            _api = api ?? new JobAdder();    // TODO FRANK: remove this null coalescer, we ALWAYS want to inject it in Startup.cs 
            _restClient = new RestClient(_api.clientUri);
            // _clientApi = restClient ?? new RestClient("http://private-76432-jobadder1.apiary-mock.com/");
        }
        
        public IEnumerable<Candidate> GetCandidates()
        {
            var request = _api.GetCandidatesAction;
            var response = _restClient.Execute(request);
            var jsonCandidates = JArray.Parse(response.Content).ToString();
            
            // Map the Jarray objects to candidates.
            var candidates = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(jsonCandidates);
            
            return candidates;
        }

        public IEnumerable<Job> GetJobs()
        {
            throw new NotImplementedException();
        }
    }
}