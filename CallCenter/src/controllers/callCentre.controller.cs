using CallCenter.Handlers;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/CallCenter")]
    public class CallCenterController
    {
        [HttpGet("AnswerCall")]
        public IActionResult AnswerCall()
        {
            return CallCenterHandler.AnswerCall();
        }

        [HttpGet("ViewCientDetails")]
        public IActionResult ViewClientDetails()
        {
            return CallCenterHandler.ViewClientDetails();
        }

        [HttpGet("ViewAgreements")]
        public IActionResult ViewAgreements()
        {
            return CallCenterHandler.ViewAgreements();
        }

        [HttpGet("ViewClientHistory")]
        public IActionResult ViewClientHistory()
        {
            return CallCenterHandler.ViewClientHistory();
        }

        [HttpPost("LogRequest")]
        public IActionResult LogRequest()
        {
            return CallCenterHandler.LogRequest();
        }

        [HttpPost("SubmitRequest")]
        public IActionResult SubmitRequest()
        {
            return CallCenterHandler.SubmitRequest();
        }

        [HttpPost("AddCallToRequest")]
        public IActionResult AddCallToRequest()
        {
            return CallCenterHandler.AddCallToRequest();
        }
    }
}