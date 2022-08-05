using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalAppTrial.Repository;

namespace SignalAppTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {
        private DataRepository dataRepository;

        public SignalController()
        {
            this.dataRepository = new DataRepository();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var result= dataRepository.GetAll();
            return Ok(result);
        }
    }
}
