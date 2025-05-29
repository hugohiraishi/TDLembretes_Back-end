using Microsoft.AspNetCore.Mvc;
using TDLembretes.DTO.TarefaOficial;
using TDLembretes.DTO.UsuarioTarefasOficial;
using TDLembretes.Repositories.Data;
using TDLembretes.Services;

namespace TDLembretes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioTarefasOficialController : Controller
    {
        private readonly UsuarioTarefasOficialService _usuarioTarefasOficialService;

        public UsuarioTarefasOficialController(UsuarioTarefasOficialService usuarioTarefasOficialService)
        {
            _usuarioTarefasOficialService = usuarioTarefasOficialService;
        }

        [HttpPost("adotar")]
        public async Task<IActionResult> AdotarTarefa([FromQuery] string usuarioId, [FromQuery] string tarefaOficialId)
        {
            try
            {
                await _usuarioTarefasOficialService.AdotarTarefaAsync(usuarioId, tarefaOficialId);
                return Ok("Tarefa adotada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarTarefa([FromQuery] string usuarioId, [FromQuery] string tarefaOficialId, [FromBody] UsuarioTarefasOficialDTO dto)
        {
            try
            {
                await _usuarioTarefasOficialService.AtualizarTarefaAsync(usuarioId, tarefaOficialId, dto);
                return Ok("Tarefa atualizada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{usuarioId}/tarefas-oficiais/{tarefaId}/status")]
        public async Task<IActionResult> AtualizarStatus(string usuarioId, string tarefaId, [FromBody] AtualizarStatusOficialDTO dto)
        {
            try
            {
                await _usuarioTarefasOficialService.AtualizarStatusTarefaUsuarioAsync(usuarioId, tarefaId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{usuarioId}/tarefas-oficiais/{tarefaId}/comprovacao")]
        public async Task<IActionResult> AtualizarComprovacaoUrl(string usuarioId, string tarefaId, [FromBody] ComprovaçãoURLDTO dto)
        {
            try
            {
                await _usuarioTarefasOficialService.AtualizarComprovacaoUrlAsync(usuarioId, tarefaId, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("usuario/{usuarioId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> RemoverTarefa(string usuarioId, string tarefaId)
        {
            try
            {
                await _usuarioTarefasOficialService.RemoverTarefaAsync(usuarioId, tarefaId);
                return Ok("Tarefa removida com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> GetTarefasDoUsuario(string usuarioId)
        {
            var tarefas = await _usuarioTarefasOficialService.GetTarefasPorUsuarioAsync(usuarioId);
            return Ok(tarefas);
        }

        [HttpGet("usuario/{usuarioId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> GetTarefaDoUsuario(string usuarioId, string tarefaId)
        {
            var tarefa = await _usuarioTarefasOficialService.GetTarefaPorUsuarioETarefaAsync(usuarioId, tarefaId);
            if (tarefa == null) return NotFound();
            return Ok(tarefa);
        }


    }
}
