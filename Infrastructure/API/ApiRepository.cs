using System;
using System.Collections.Generic;
using System.Linq;
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
    public class ApiRepository : IRepository
    {
        private IApiClient _api;
        private IRestClient _restClient; 

        public ApiRepository(IApiClient api)
        {
            _api = api;
            _restClient = new RestClient(_api.ClientUri);
        }
        
        public IEnumerable<Candidate> GetCandidates()
        {
            var jsonCandidates = ExecuteExternalApiRequest(_api.GetCandidatesAction);
            var candidates = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(jsonCandidates);
            
            return candidates;
        }

        public IEnumerable<Job> GetJobs()
        {
            var jsonJobs = ExecuteExternalApiRequest(_api.GetJobsAction);
            var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(jsonJobs);
            
            return jobs;
        }
        
        // NOTE: Ideally I'd have a direct action to the jobAdder API to get this, but we gotta work within the confines of their system. 
        public Job GetJob(int jobId)
        {
            var jsonJobs = ExecuteExternalApiRequest(_api.GetJobsAction);
            var jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(jsonJobs);
            
            return GetJobs().FirstOrDefault(x => x.Id == jobId);
        }

        private string ExecuteExternalApiRequest(RestRequest request)
        {
            var response = _restClient.Execute(request);
            var jsonCandidates = JArray.Parse(response.Content).ToString();
            return jsonCandidates;
        }
    }
}