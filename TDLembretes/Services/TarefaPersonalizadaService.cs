using TDLembretes.DTO;
using TDLembretes.Models;
using TDLembretes.Repositories;

namespace TDLembretes.Services
{
    public class TarefaPersonalizadaService
    {

        private readonly TarefaPersonalizadaRepository _tarefaPersonalizadaRepository;

        public TarefaPersonalizadaService(TarefaPersonalizadaRepository tarefaPersonalizadaRepository)
        {
            _tarefaPersonalizadaRepository = tarefaPersonalizadaRepository;
        }

        //POST
        public async Task<string> CriarTarefaPersonalizada(TarefaPersonalizadaDTO dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Titulo) ||
                (string.IsNullOrWhiteSpace(dto.Descricao) ||
                dto.DataFinalizacao == null ||
                dto.Prioridade == null))
            {
                throw new ArgumentException("Todos os campos devem ser preenchidos corretamente!");
            }


            TarefaPersonalizada novaTarefaPersonalizada = new TarefaPersonalizada(
                Guid.NewGuid().ToString(),
                dto.Titulo,
                dto.Descricao,
                DateTime.UtcNow,
                dto.DataFinalizacao,
                StatusTarefa.Pendente,
                dto.Prioridade
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
            tarefa.Status = dto.Status;

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
        private async Task<TarefaPersonalizada?> GetTarefaPersonalizada(string tarefaPersonalizadaId)
        {
            TarefaPersonalizada? tarefa = await _tarefaPersonalizadaRepository.GetTarefaPersonalizada(tarefaPersonalizadaId);

            return tarefa;
        }

        public async Task<TarefaPersonalizada> GetTarefaPersonalizadaOrThrowException(string tarefaPersonalizadalId)
        {
            TarefaPersonalizada? tarefa = await GetTarefaPersonalizada(tarefaPersonalizadalId);
            if (tarefa == null)
            {
                throw new Exception("Usuario não encontrado!");
            }

            return tarefa;
        }


    }
}
