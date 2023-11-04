using Azure.Messaging;
using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{
    [ApiController]
    [Route("/api/requestLog")]
    public class RequestLogController : ControllerBase
    {
        private readonly RequestLogRepository _requestLogRepository;
        private readonly TechnicianRepository _technicianRepository;
        private readonly EmployeeRepository _employeeRepository;
        private readonly ClientRepository _clientRepository;

        public RequestLogController(RequestLogRepository requestLogRepository, TechnicianRepository technicianRepository, EmployeeRepository employeeRepository, ClientRepository clientRepository)
        {
            _requestLogRepository = requestLogRepository;
            _technicianRepository = technicianRepository;
            _employeeRepository = employeeRepository;
            _clientRepository = clientRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddRequestLog([FromBody] AddRequestLogRequest requestLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            RequestLog newRequestLog = new RequestLog()
            {
                requestId = Guid.NewGuid(),
                clientId = requestLog.clientId,
                lastCallDate = requestLog.lastCallDate,
                callDuration = requestLog.callDuration,
                technicianId = requestLog.technicianId,
                priorityLevel = requestLog.priorityLevel,
                status = requestLog.status
            };

            await _requestLogRepository.AddRequestLog(newRequestLog);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateRequestLog([FromBody] UpdateRequestLogRequest requestLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            RequestLog existingRequestLog = await _requestLogRepository.GetRequestLogById(requestLog.requestId);

            RequestLog newRequestLog = new RequestLog()
            {
                requestId = existingRequestLog.requestId,
                clientId = existingRequestLog.clientId,
                lastCallDate = requestLog.lastCallDate ?? existingRequestLog.lastCallDate,
                callDuration = requestLog.callDuration ?? existingRequestLog.callDuration,
                technicianId = requestLog.technicianId ?? existingRequestLog.technicianId,
                priorityLevel = requestLog.priorityLevel ?? existingRequestLog.priorityLevel,
                status = requestLog.status ?? existingRequestLog.status
            };

            await _requestLogRepository.UpdateRequestLog(newRequestLog);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRequestLogs()
        {
            List<RequestLog> requestLogs = await _requestLogRepository.GetAllRequestLogs();
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

            // TODO: This is going to be very slow on larger datasets, FIX
            foreach (var requestLog in requestLogs)
            {
                Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                Client client = await _clientRepository.GetClientById(requestLog.clientId);

                HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                {
                    requestId = requestLog.requestId,
                    clientName = client.clientName,
                    clientPhoneNumber = client.phoneNumber,
                    lastCallDate = requestLog.lastCallDate,
                    callDuration = requestLog.callDuration,
                    employeeName = employee.employeeName,
                    department = employee.department,
                    priorityLevel = requestLog.priorityLevel,
                    status = requestLog.status
                };

                hydratedResponses.Add(hydratedRequestLogResponse);
            }

            return Ok(hydratedResponses);
        }


        [HttpGet("getby/requestId/{requestId}")]
        public async Task<IActionResult> GetRequestLogByRequestLogId([FromRoute] string requestId)
        {
            if (Guid.TryParse(requestId, out Guid result))
            {
                RequestLog requestLog = await _requestLogRepository.GetRequestLogById(result);
                if (requestLog == null)
                {
                    return NotFound();
                }

                Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                Client client = await _clientRepository.GetClientById(requestLog.clientId);

                HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                {
                    requestId = requestLog.requestId,
                    clientName = client.clientName,
                    clientPhoneNumber = client.phoneNumber,
                    lastCallDate = requestLog.lastCallDate,
                    callDuration = requestLog.callDuration,
                    employeeName = employee.employeeName,
                    department = employee.department,
                    priorityLevel = requestLog.priorityLevel,
                    status = requestLog.status
                };

                return Ok(hydratedRequestLogResponse);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetRequestLogByClienId([FromRoute] string clientId)
        {
            if (Guid.TryParse(clientId, out Guid result))
            {
                List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogByClientId(result);
                if (requestLogs.Count < 1)
                {
                    return NotFound();
                }

                List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

                // TODO: This is going to be very slow on larger datasets, FIX
                foreach (var requestLog in requestLogs)
                {
                    Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                    Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                    Client client = await _clientRepository.GetClientById(requestLog.clientId);

                    HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                    {
                        requestId = requestLog.requestId,
                        clientName = client.clientName,
                        clientPhoneNumber = client.phoneNumber,
                        lastCallDate = requestLog.lastCallDate,
                        callDuration = requestLog.callDuration,
                        employeeName = employee.employeeName,
                        department = employee.department,
                        priorityLevel = requestLog.priorityLevel,
                        status = requestLog.status
                    };

                    hydratedResponses.Add(hydratedRequestLogResponse);
                }

                return Ok(hydratedResponses);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/technicianId/{technicianId}")]
        public async Task<IActionResult> GetRequestLogByTechnicianId([FromRoute] string technicianId)
        {
            if (Guid.TryParse(technicianId, out Guid result))
            {
                List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogByTechnicianId(result);
                if (requestLogs.Count < 1)
                {
                    return NotFound();
                }

                List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

                // TODO: This is going to be very slow on larger datasets, FIX
                foreach (var requestLog in requestLogs)
                {
                    Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                    Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                    Client client = await _clientRepository.GetClientById(requestLog.clientId);

                    HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                    {
                        requestId = requestLog.requestId,
                        clientName = client.clientName,
                        clientPhoneNumber = client.phoneNumber,
                        lastCallDate = requestLog.lastCallDate,
                        callDuration = requestLog.callDuration,
                        employeeName = employee.employeeName,
                        department = employee.department,
                        priorityLevel = requestLog.priorityLevel,
                        status = requestLog.status
                    };

                    hydratedResponses.Add(hydratedRequestLogResponse);
                }

                return Ok(hydratedResponses);
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/status/{status}")]
        public async Task<IActionResult> GetRequestLogByStatus([FromRoute] string status)
        {

            List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogtByStatus(status);
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

            // TODO: This is going to be very slow on larger datasets, FIX
            foreach (var requestLog in requestLogs)
            {
                Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                Client client = await _clientRepository.GetClientById(requestLog.clientId);

                HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                {
                    requestId = requestLog.requestId,
                    clientName = client.clientName,
                    clientPhoneNumber = client.phoneNumber,
                    lastCallDate = requestLog.lastCallDate,
                    callDuration = requestLog.callDuration,
                    employeeName = employee.employeeName,
                    department = employee.department,
                    priorityLevel = requestLog.priorityLevel,
                    status = requestLog.status
                };

                hydratedResponses.Add(hydratedRequestLogResponse);
            }

            return Ok(hydratedResponses);

        }

        [HttpGet("getby/priority/{priority}")]
        public async Task<IActionResult> GetRequestLogByPriority([FromRoute] string priority)
        {
            List<RequestLog> requestLogs = await _requestLogRepository.GetRequestLogtByPriority(priority);
            if (requestLogs.Count < 1)
            {
                return NotFound();
            }

            List<HydratedRequestLogResponse> hydratedResponses = new List<HydratedRequestLogResponse>();

            // TODO: This is going to be very slow on larger datasets, FIX
            foreach (var requestLog in requestLogs)
            {
                Technician technician = await _technicianRepository.GetTechnicianById(requestLog.technicianId);
                Employee employee = await _employeeRepository.GetEmployeeById(technician.employeeId);
                Client client = await _clientRepository.GetClientById(requestLog.clientId);

                HydratedRequestLogResponse hydratedRequestLogResponse = new HydratedRequestLogResponse()
                {
                    requestId = requestLog.requestId,
                    clientName = client.clientName,
                    clientPhoneNumber = client.phoneNumber,
                    lastCallDate = requestLog.lastCallDate,
                    callDuration = requestLog.callDuration,
                    employeeName = employee.employeeName,
                    department = employee.department,
                    priorityLevel = requestLog.priorityLevel,
                    status = requestLog.status
                };

                hydratedResponses.Add(hydratedRequestLogResponse);
            }

            return Ok(hydratedResponses);
        }

    }
}