using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("pedido-seis-meses/{id:int}")]
        public IActionResult ClienteEPEdidoSeisMeses([FromRoute] int id)
        {
            try
            {
                return Ok(_clienteRepository.ObterPedidoSeisMeses(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
