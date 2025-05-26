using Microsoft.AspNetCore.Mvc;
using TDLembretes.DTO.Produto;
using TDLembretes.DTO.TarefaOficial;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;
using TDLembretes.Services;

namespace TDLembretes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetTodos()
        {
            var produtos = await _produtoService.GetTodosProdutos();
            return Ok(produtos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Get(string id)
        {
            try
            {
                var produto = await _produtoService.GetProdutoDTO(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] ProdutoDTO dto)
        {
            try
            {
                var id = await _produtoService.CriarProduto(dto);
                return CreatedAtAction(nameof(Get), new { id }, id);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] ProdutoDTO dto)
        {
            try
            {
                await _produtoService.UpdateProduto(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _produtoService.DeleteProduto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }
    }
}

