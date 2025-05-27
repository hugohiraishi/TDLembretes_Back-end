using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TDLembretes.DTO.TarefaPersonalizada;
using TDLembretes.Models;
using TDLembretes.Repositories;

namespace TDLembretes.Services
{
    public class TarefaPersonalizadaService
    {

        private readonly TarefaPersonalizadaRepository _tarefaPersonalizadaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TarefaPersonalizadaService(TarefaPersonalizadaRepository tarefaPersonalizadaRepository, IHttpContextAccessor httpContextAccessor)
        {
            _tarefaPersonalizadaRepository = tarefaPersonalizadaRepository;
            _httpContextAccessor = httpContextAccessor;
        }
     

        //POST
        public async Task<string> CriarTarefaPersonalizada(CriarTarefaPersonalizadaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo) ||
                (string.IsNullOrWhiteSpace(dto.Descricao) ||
                dto.DataFinalizacao == null ||
                dto.Prioridade == null))
            {
                throw new ArgumentException("Todos os campos devem ser preenchidos corretamente!");
            }

            var usuarioId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(usuarioId))
            {
                throw new UnauthorizedAccessException("Usuário não autenticado ou sessão expirou.");
            }

            TarefaPersonalizada novaTarefaPersonalizada = new TarefaPersonalizada(
                Guid.NewGuid().ToString(),
                dto.Titulo,
                dto.Descricao,
                DateTime.UtcNow,
                dto.DataFinalizacao,
                StatusTarefa.EmAndamento,
                dto.Prioridade,
                usuarioId
                );

            await _tarefaPersonalizadaRepository.AddTarefaPersonalizada(novaTarefaPersonalizada);

            return novaTarefaPersonalizada.Id;
        }


        //PUT
        public async Task UpdateTarefaPersonalizada(string id, AtualizarTarefaPersonalizadaDTO dto)
        {
            TarefaPersonalizada? tarefa = await _tarefaPersonalizadaRepository.GetTarefaPersonalizada(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.DataFinalizacao = dto.DataFinalizacao;

            await _tarefaPersonalizadaRepository.UpdateTarefaPersonalizada(tarefa);
        }

        public async Task UpdateStatusTarefaPersonalizada(string id, AtualizarStatusPersonalizadaDTO statusDto)
        {
            TarefaPersonalizada? tarefa = await _tarefaPersonalizadaRepository.GetTarefaPersonalizada(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            if (DateTime.UtcNow > tarefa.DataFinalizacao)
            {
                tarefa.Status = StatusTarefa.Expirada;
            }
            else
            {
                tarefa.Status = statusDto.Status == StatusTarefa.Concluida
                                ? StatusTarefa.Concluida
                                : StatusTarefa.EmAndamento;
            }

            await _tarefaPersonalizadaRepository.UpdateTarefaPersonalizada(tarefa);
        }



        //DELET
        public async Task DeleteTarefaPersonalizada(string id)
        {
            TarefaPersonalizada? tarefa = await _tarefaPersonalizadaRepository.GetTarefaPersonalizada(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            await _tarefaPersonalizadaRepository.DeleteTarefaPersonalizada(tarefa);
        }


        //GET
        public async Task<IEnumerable<TarefaPersonalizada>> GetTarefasPorUsuarioAsync()
        {
            var usuarioId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(usuarioId))
                throw new UnauthorizedAccessException("Usuário não autenticado.");

            return await _tarefaPersonalizadaRepository.GetTarefasPorUsuarioAsync(usuarioId);
        }


    }
}
