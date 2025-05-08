using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDLembretes.DTO;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;
using TDLembretes.Services;
namespace TDLembretes.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CriarTarefaOficialController : Controller
    {
        private readonly TarefaOficialService _tarefaOficialService;
        private readonly tdlDbContext _context;

        public CriarTarefaOficialController(TarefaOficialService tarefaOficialService, tdlDbContext context )
        {
            _tarefaOficialService = tarefaOficialService;
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaOficial>>> GetTarefaOficial()
        {
            return await _context.TarefasOficial.ToListAsync();
        }


        [HttpPost("CriarTarefaOficial")]
        public async Task<ActionResult<string>> CriarTarefaOficial(TarefaOficialDTO dto)
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
