using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalAppTrial.DataAccess.Abstract;

namespace SignalAppTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : ControllerBase
    {
        private readonly ISignalRepository _signalRepository;

        public SignalController(ISignalRepository signalRepository)
        {
            _signalRepository = signalRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var result= _signalRepository.GetAll();
            return Ok(result);
        }
    }
}
