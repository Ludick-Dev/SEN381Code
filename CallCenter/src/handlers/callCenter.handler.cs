using CallCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Handlers
{
    public class CallCenterHandler
    {
        List<CallReport> callReports;

        public CallCenterHandler()
        {
            this.callReports = new List<CallReport>();
        }

        public static IActionResult AnswerCall()
        {
            // Auth
            // checkPermision
            // validateQuery
            // call service

            throw new NotImplementedException();
        }

        public static IActionResult ViewClientDetails()
        {
            throw new NotImplementedException();
        }

        public static IActionResult ViewAgreements()
        {
            throw new NotImplementedException();
        }

        public static IActionResult ViewClientHistory()
        {
            throw new NotImplementedException();
        }

        public static IActionResult LogRequest()
        {
            throw new NotImplementedException();
        }

        public static IActionResult SubmitRequest()
        {
            throw new NotImplementedException();
        }

        public static IActionResult AddCallToRequest()
        {
            throw new NotImplementedException();
        }
    }
}