using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Core.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Infrastructure
{
    public class JobAdderConsumer
    {
        private IRestClient _clientApi;

        public JobAdderConsumer(IRestClient restClient)
        {
            // _clientApi = restClient;    // TODO FRANK: Abstract and Inject this better. Currently Too tightly coupled to the API
            _clientApi = restClient ?? new RestClient("http://private-76432-jobadder1.apiary-mock.com/");
        }
        public IEnumerable<Candidate> GetCandidates()
        {
            var request = new RestRequest("candidates", Method.GET);
            var response = _clientApi.Execute(request);
            var jsonCandidates = JArray.Parse(response.Content).ToString();
            
            // Map the Jarray objects to candidates.
            var candidates = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(jsonCandidates);
            
            return candidates;
        }

        // public static void GetJobs()
        // {
        //     string baseUri = "https://jobadder1.docs.apiary.io/#reference/0/candidate-collection/list-all-jobs/";            
        // }
        
    }
}