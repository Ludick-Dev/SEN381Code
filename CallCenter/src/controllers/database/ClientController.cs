using CallCenter.Models;
using CallCenter.Models.Responses;
using CallCenter.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CallCenter.Controllers
{

    [ApiController]
    [Route("/api/client")]
    public class ClientController : ControllerBase
    {
        private readonly ClientRepository _clientRepository;

        public ClientController(ClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddClient([FromBody] AddClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Client newClient = new Client()
            {
                clientId = Guid.NewGuid(),
                clientName = client.clientName,
                phoneNumber = client.phoneNumber,
                clientType = client.clientType,
                contracts = client.contracts,
                clientAddress = client.clientAddress,
                lastCallDate = null,
                clientNotes = null,
            };

            await _clientRepository.AddClient(newClient);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestModelStateResponse.BadRequestModelState(ModelState);
            }

            Client existingClient = await _clientRepository.GetClientById(client.clientId);

            Client newClient = new Client()
            {
                clientId = existingClient.clientId,
                clientName = client.clientName,
                phoneNumber = client.phoneNumber,
                clientType = (Types.ClientTypes)client.clientType,
                contracts = client.contracts,
                clientAddress = client.clientAddress,
                lastCallDate = null,
                clientNotes = null,
            };

            await _clientRepository.UpdateClient(newClient);
            return Ok();
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetClients()
        {
            List<Client> clients = await _clientRepository.GetAllClients();
            if (clients == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("getby/clientId/{clientId}")]
        public async Task<IActionResult> GetClientByClientId([FromRoute] string reportId)
        {
            if (Guid.TryParse(reportId, out Guid result))
            {
                Client client = await _clientRepository.GetClientById(result);
                if (client == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            else
            {
                return BadRequest(new ErrorResponse("Invalid ID format"));
            }
        }

        [HttpGet("getby/clientName/{clientName}")]
        public async Task<IActionResult> GetClientByName([FromRoute] string clientName)
        {
            List<Client> clients = await _clientRepository.GetClientByName(clientName);
            if (clients.Count < 1)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("getby/phoneNumber/{phoneNumber}")]
        public async Task<IActionResult> GetClientByPhoneNumber([FromRoute] string phoneNumber)
        {
            Client client = await _clientRepository.GetClientByPhoneNumber(phoneNumber);
            if (client != null)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}