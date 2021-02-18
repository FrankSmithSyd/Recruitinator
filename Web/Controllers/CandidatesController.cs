using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidateService _service;
        
        public CandidatesController(ICandidateService service)
        {
            _service = service;            
        }
        
        public IActionResult Index()
        {
            var candidates = _service.GetAllCandidates();
            
            return View(candidates);
        }
    }
}