using TDLembretes.Models;
using TDLembretes.Repositories;
using System.Security.Claims;
using System.Linq.Expressions;
using TDLembretes.DTO.TarefaOficial;
using TDLembretes.DTO.Produto;


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
        public async Task<string> CriarTarefaOficial(CriarTarefaOficialDTO dto)
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
                dto.Pontos,
                DateTime.UtcNow,
                dto.DataFinalizacao,
                StatusTarefa.EmAndamento,
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
            tarefa.Status = dto.Status;
            tarefa.Prioridade = dto.Prioridade;
            tarefa.DataFinalizacao = dto.DataFinalizacao;

            await _tarefaOficialRepository.UpdateTarefaOficial(tarefa);
        }

        //PUT - ComprovaçãoURL

        public async Task UpdateComprovacaoURL(string id, ComprovaçãoURLDTO dto)
        {
            TarefaOficial? tarefa = await _tarefaOficialRepository.GetTarefaOficial(id);
            if (tarefa == null)
                throw new Exception("Tarefa não encontrada");

            tarefa.ComprovacaoUrl = dto.ComprovacaoUrl;

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
        public async Task<TarefaOficialDTO> GetTarefaOficialDTO(string tarefaOficialId)
        {
            var tarefaOficial = await GetTarefaOficialOrThrowException(tarefaOficialId);

            return new TarefaOficialDTO
            {
                Titulo = tarefaOficial.Titulo,
                Descricao = tarefaOficial.Descricao,
                Prioridade = tarefaOficial.Prioridade,
                Pontos = tarefaOficial.Pontos,
                DataCriacao = tarefaOficial.DataCriacao,
                DataFinalizacao = tarefaOficial.DataFinalizacao,
                ComprovacaoUrl = tarefaOficial.ComprovacaoUrl,
                Status = tarefaOficial.Status,
                StatusComprovacao= tarefaOficial.StatusComprovacao,
            };
        }

        public async Task<List<TarefaOficialDTO>> GetTodasTarefasOficial()
        {
            var tarefaOficial = await _tarefaOficialRepository.GetTodasTarefasOficial();

            return tarefaOficial.Select(tarefaOficial => new TarefaOficialDTO
            {
                Titulo = tarefaOficial.Titulo,
                Descricao = tarefaOficial.Descricao,
                Prioridade = tarefaOficial.Prioridade,
                Pontos = tarefaOficial.Pontos,
                DataCriacao = tarefaOficial.DataCriacao,
                DataFinalizacao = tarefaOficial.DataFinalizacao,
                ComprovacaoUrl = tarefaOficial.ComprovacaoUrl,
                Status = tarefaOficial.Status,
                StatusComprovacao = tarefaOficial.StatusComprovacao,
            }).ToList();
        }

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
