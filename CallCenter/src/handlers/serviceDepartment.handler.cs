using CallCenter.Models;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Handlers{
    public class ServiceDepartmentHandler{
        
        List<WorkRequest> serviceRequests;
        List<Technician> technicians;
        WorkRequest selectedServiceRequest;

        public ServiceDepartmentHandler()
        {
            this.serviceRequests = new List<WorkRequest>();
        }

        public static IActionResult GetWorkRequest()
        {
            // Auth
            // checkPermision
            // validateQuery
            // call service
            
            throw new NotImplementedException();
        }

        public static IActionResult TrackRequest()
        {
            throw new NotImplementedException();
        }

        public static IActionResult AddRequests()
        {
            throw new NotImplementedException();
        }

        public static IActionResult EscalateRequests()
        {
            throw new NotImplementedException();
        }

        public static IActionResult ReassignRequests()
        {
            throw new NotImplementedException();
        }

        public static IActionResult DeleteRequest()
        {
            throw new NotImplementedException();
        }
    }
}