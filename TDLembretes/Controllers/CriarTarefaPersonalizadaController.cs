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
    public class CriarTarefaPersonalizadaController : Controller
    {
        private readonly TarefaPersonalizadaService _tarefaPersonalizadaService;
        private readonly tdlDbContext _context;

        public CriarTarefaPersonalizadaController(TarefaPersonalizadaService tarefaPersonalizadaService, tdlDbContext context)
        {
            _tarefaPersonalizadaService = tarefaPersonalizadaService;
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaPersonalizada>>> GetTarefaPersonalizada()
        {
            return await _context.TarefasPersonalizada.ToListAsync();
        }

        [HttpPost("CriarTarefaPersonalizada")]
        public async Task<ActionResult<string>> CriarTarefaPersonalizada(TarefaPersonalizadaDTO dto)
        {
            try
            {
                var tarefaPersonalizada = await _tarefaPersonalizadaService.CriarTarefaPersonalizada(dto);

                return Ok(new { Message = "Tarefa criada com sucesso! " });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefaPersonalizada(string id, [FromBody] AtualizarTarefaPersonalizadaDTO dto)
        {
            await _tarefaPersonalizadaService.UpdateTarefaPersonalizada(id, dto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaPersonalizada(string id)
        {
            try
            {
                await _tarefaPersonalizadaService.DeleteTarefaPersonalizada(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
}