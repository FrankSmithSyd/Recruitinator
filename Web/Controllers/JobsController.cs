using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _service;
        
        public JobsController(IJobService service)
        {
            _service = service;            
        }
        
        public IActionResult Index()
        {
            var jobs = _service.GetAllJobs();
            
            return View(jobs);
        }
        
        public IActionResult Details(int id)
        {
            var job = _service.GetJob(id);
            
            return View(job);
        }

        public IActionResult CandidateJobMatches(int jobId)
        {
            var candidateJobMatches = _service.GetCandidateJobMatches(jobId);
        
            return View(candidateJobMatches);
        }
    }
}