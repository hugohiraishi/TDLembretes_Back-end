using Microsoft.AspNetCore.Mvc;
using TDLembretes.Services;
using TDLembretes.DTO.Compra;

namespace TDLembretes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : Controller
    {
        private readonly CompraService _compraService;

        public CompraController(CompraService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
        public async Task<IActionResult> RealizarCompra([FromBody] ComprarRequest request)
        {
            try
            {
                var sucesso = await _compraService.RealizarCompra(request.UsuarioId, request.ProdutoId, request.Quantidade);
                return Ok(new { mensagem = "Compra realizada com sucesso.", sucesso });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}
