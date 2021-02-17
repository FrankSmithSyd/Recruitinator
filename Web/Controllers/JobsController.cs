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
    }
}