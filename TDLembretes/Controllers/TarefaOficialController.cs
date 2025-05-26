using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDLembretes.DTO.Produto;
using TDLembretes.DTO.TarefaOficial;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;
using TDLembretes.Services;
namespace TDLembretes.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaOficialController : Controller
    {
        private readonly TarefaOficialService _tarefaOficialService;

        public TarefaOficialController(TarefaOficialService tarefaOficialService, tdlDbContext context )
        {
            _tarefaOficialService = tarefaOficialService;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaOficialDTO>>> GetTodos()
        {
            var tarefaOficial = await _tarefaOficialService.GetTodasTarefasOficial();
            return Ok(tarefaOficial);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaOficialDTO>> Get(string id)
        {
            try
            {
                var tarefaOficial = await _tarefaOficialService.GetTarefaOficialDTO(id);
                return Ok(tarefaOficial);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }


        [HttpPost("CriarTarefaOficial")]
        public async Task<ActionResult<string>> CriarTarefaOficial(CriarTarefaOficialDTO dto)
        {
            try
            {
                var tarefaOficial = await _tarefaOficialService.CriarTarefaOficial(dto);

                return Ok(new {Message = "Tarefa criada com sucesso! " });
            }
            catch (Exception ex)
            {
                return BadRequest(new {Message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefaOficial(string id, [FromBody] AtualizarTarefaOficialDTO dto)
        {
            try
            {
                await _tarefaOficialService.UpdateTarefaOficial(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPut("/ComprovaçãoURL/{id}")]
        public async Task<IActionResult> UpdateComprovacaoURL(string id, [FromBody] ComprovaçãoURLDTO dto)
        {
            try
            {
                await _tarefaOficialService.UpdateComprovacaoURL(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaOficial(string id)
        {
            try
            {
                await _tarefaOficialService.DeleteTarefaOficial(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}
