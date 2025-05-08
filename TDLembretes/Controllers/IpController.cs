using Microsoft.AspNetCore.Mvc;
using TDLembretes.Services;

namespace TDLembretes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IpController : ControllerBase
    {
        private readonly IpService _ipService;

        public IpController(IpService ipService)
        {
            _ipService = ipService;
        }

        [HttpGet("obter-ip")]
        public IActionResult ObterIp()
        {
            try
            {
                var ipCliente = _ipService.ObterIp();
                return Ok(new { IpCliente = ipCliente });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Error = "Erro ao obter o IP", Details = ex.Message });
            }
        }
    }
}
