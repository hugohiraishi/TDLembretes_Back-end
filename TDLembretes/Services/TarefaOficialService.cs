using TDLembretes.Models;
using TDLembretes.Repositories;
using TDLembretes.DTO;
using System.Security.Claims;
using System.Linq.Expressions;


namespace TDLembretes.Services
{
    public class TarefaOficialService
    {

        private readonly TarefaOficialRepository _tarefaOficialRepository;


        public TarefaOficialService(TarefaOficialRepository tarefaOficialRepository)
        {
            _tarefaOficialRepository = tarefaOficialRepository;
        }


        //POST
        public async Task<string> CriarTarefaOficial(TarefaOficialDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo) ||
                (string.IsNullOrWhiteSpace(dto.Descricao) ||
                dto.DataFinalizacao == null ||
                dto.Prioridade == null))
                {
                throw new ArgumentException("Todos os campos devem ser preenchidos corretamente!");
                }


            TarefaOficial novaTarefaOficial = new TarefaOficial(
                Guid.NewGuid().ToString(),
                dto.Titulo,
                dto.Descricao,
                dto.Prioridade,
                0,
                DateTime.UtcNow,
                dto.DataFinalizacao,
                null,
                StatusComprovacao.AguardandoAprovacao

                );

            await _tarefaOficialRepository.AddTarefaOficial(novaTarefaOficial);

            return novaTarefaOficial.Id;
        }


        //PUT
        public async Task UpdateTarefaOficial(string id, AtualizarTarefaOficialDTO dto)
        {
            TarefaOficial? tarefa = await _tarefaOficialRepository.GetTarefaOficial(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            tarefa.Titulo = dto.Titulo;
            tarefa.Descricao = dto.Descricao;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.ComprovacaoUrl = dto.ComprovacaoUrl;
            tarefa.DataFinalizacao = dto.DataFinalizacao;

            await _tarefaOficialRepository.UpdateTarefaOficial(tarefa);
        }



        //DELET
        public async Task DeleteTarefaOficial(string id)
        {
            TarefaOficial? tarefa = await _tarefaOficialRepository.GetTarefaOficial(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada.");

            await _tarefaOficialRepository.DeleteTarefaOficial(tarefa);
        }


        //GET
        private async Task<TarefaOficial?> GetTarefaOficial(string tarefaOficialId)
        {
            TarefaOficial? tarefaOficial = await _tarefaOficialRepository.GetTarefaOficial(tarefaOficialId);

            return tarefaOficial;
        }

        public async Task<TarefaOficial> GetTarefaOficialOrThrowException(string tarefaOficialId)
        {
            TarefaOficial? tarefaOficial = await GetTarefaOficial(tarefaOficialId);
            if (tarefaOficial == null)
            {
                throw new Exception("Usuario não encontrado!");
            }

            return tarefaOficial;
        }


    }
}
