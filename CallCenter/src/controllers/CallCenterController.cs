using CallCenter.Handlers;
using Microsoft.AspNetCore.Mvc;
using CallCenter.Services;
using CallCenter.src.dataAccess;
using CallCenter.src.services;
using CallCenter.src.models;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/CallCenter")]
    public class CallCenterController : Controller
    {
        [HttpGet("CallCenter")]
        public IActionResult CallCenter()
        {
            return View("CallCenter");
        }
        //display technicians in dropdown menu
        [HttpGet("GetTechnicians")]
        public IActionResult GetTechnicians()
        {
            CallCenterDataAccess dataAccess = new CallCenterDataAccess();
            var technicians = dataAccess.GetTechnicianDetails();
            return Json(technicians);
        }

        //notifiy selected technician of new "express" work request
        [HttpPost("NotifyTechnician")]
        public IActionResult NotifyTechnician([FromBody] NotifyTechnicianRequest request)
        {
            var dataAccess = new CallCenterDataAccess();
            (string email, string phoneNumber) contactDetails = dataAccess.GetTechnicianContactDetails(request.TechnicianId);

            string message = "New Express Work Request!\n" +
                 "Client Name: " + request.ClientName + "\n" +
                 "Client Phone: " + request.ClientPhone + "\n" +
                 "Client Address: " + request.ClientAddress + "\n" +
                 "Problem Description: " + request.ProblemDescription;
            try
            {
                if (request.NotifyEmail)
                {
                    //keep getting banned from sendgrid lol
                }
                if (request.NotifySMS)
                {
                    var smsService = new SMSNotificationServices();
                    smsService.Notify(message, contactDetails.phoneNumber);
                    ViewBag.numberalert = contactDetails.phoneNumber;
                }
                if (request.NotifyWhatsapp)
                {
                    var whatsappService = new WhatsappNotificationServices();
                    whatsappService.Notify(message, contactDetails.phoneNumber);
                }

                return Ok("Notifications sent successfully!");
            }
            catch (Exception ex) 
            {
                return BadRequest("Error sending notification. Phone number: " + contactDetails.phoneNumber + ". Email: "+ contactDetails.email + ". Error: " + ex.Message);
            }
        }

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