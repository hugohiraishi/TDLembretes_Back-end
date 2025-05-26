using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TDLembretes.DTO.TarefaPersonalizada;
using TDLembretes.Models;
using TDLembretes.Repositories.Data;
using TDLembretes.Services;

namespace TDLembretes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaPersonalizadaController : Controller
    {
        private readonly TarefaPersonalizadaService _tarefaPersonalizadaService;

        public TarefaPersonalizadaController(TarefaPersonalizadaService tarefaPersonalizadaService)
        {
            _tarefaPersonalizadaService = tarefaPersonalizadaService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TarefaPersonalizada>>> GetTarefasDoUsuario()
        {
            try
            {
                var tarefas = await _tarefaPersonalizadaService.GetTarefasPorUsuarioAsync();
                return Ok(tarefas);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<string>> CriarTarefaPersonalizada(CriarTarefaPersonalizadaDTO dto)
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