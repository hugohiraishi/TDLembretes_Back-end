using TDLembretes.DTO.TarefaOficial;
using TDLembretes.DTO.UsuarioTarefasOficial;
using TDLembretes.Models;
using TDLembretes.Repositories;

namespace TDLembretes.Services
{
    public class UsuarioTarefasOficialService
    {
        private readonly UsuarioTarefasOficialRepository _usuarioTarefasOficialRepository;

        public UsuarioTarefasOficialService(UsuarioTarefasOficialRepository usuarioTarefasOficiaisRepository)
        {
            _usuarioTarefasOficialRepository = usuarioTarefasOficiaisRepository;
        }

        //"puxar a tarefa para a lista
        public async Task AdotarTarefaAsync(string usuarioId, string tarefaOficialId)
        {
            TarefaOficial? tarefa = await _usuarioTarefasOficialRepository.GetTarefaOficialAsync(tarefaOficialId);
            if (tarefa == null)
                throw new Exception("Tarefa oficial não encontrada.");

            var jaExiste = await _usuarioTarefasOficialRepository.ExistsAsync(usuarioId, tarefaOficialId);
            if (jaExiste)
                throw new Exception("Tarefa já adotada pelo usuário.");

            var novaTarefaUsuario = new UsuarioTarefasOficiais(usuarioId, tarefaOficialId)
            {
                Prioridade = tarefa.Prioridade,
                DataFinalizacao = tarefa.DataFinalizacao,
                Status = StatusTarefa.EmAndamento,
                StatusComprovacao = StatusComprovacao.AguardandoAprovacao
            };

            await _usuarioTarefasOficialRepository.CreateAsync(novaTarefaUsuario);
        }

        //Atualizar os atributos
        public async Task AtualizarTarefaAsync(string usuarioId, string tarefaOficialId, UsuarioTarefasOficialDTO  atualizacao)
        {
            var tarefaUsuario = await _usuarioTarefasOficialRepository.GetByUsuarioETarefaAsync(usuarioId, tarefaOficialId);
            if (tarefaUsuario == null)
                throw new Exception("Tarefa não encontrada na lista do usuário.");

            tarefaUsuario.Prioridade = atualizacao.Prioridade;
            tarefaUsuario.DataFinalizacao = atualizacao.DataFinalizacao;
            tarefaUsuario.ComprovacaoUrl = atualizacao.ComprovacaoUrl;

            await _usuarioTarefasOficialRepository.UpdateAsync(tarefaUsuario);
        }

        //Atualizar o Status
        public async Task AtualizarStatusTarefaUsuarioAsync(string usuarioId, string tarefaOficialId, AtualizarStatusOficialDTO dto)
        {
            var tarefaUsuario = await _usuarioTarefasOficialRepository.GetByUsuarioETarefaAsync(usuarioId, tarefaOficialId);
            if (tarefaUsuario == null)
                throw new Exception("Tarefa não encontrada na lista do usuário.");

            if (DateTime.UtcNow > tarefaUsuario.DataFinalizacao)
            {
                tarefaUsuario.Status = StatusTarefa.Expirada;
            }
            else
            {
                tarefaUsuario.Status = dto.Status == StatusTarefa.Concluida
                                        ? StatusTarefa.Concluida
                                        : StatusTarefa.EmAndamento;
            }

            await _usuarioTarefasOficialRepository.UpdateAsync(tarefaUsuario);
        }

        //Atualizar a comprovação
        public async Task AtualizarComprovacaoUrlAsync(string usuarioId, string tarefaOficialId, ComprovaçãoURLDTO dto)
        {
            var tarefaUsuario = await _usuarioTarefasOficialRepository.GetByUsuarioETarefaAsync(usuarioId, tarefaOficialId);
            if (tarefaUsuario == null)
                throw new Exception("Tarefa não encontrada na lista do usuário.");

            tarefaUsuario.ComprovacaoUrl = dto.ComprovacaoUrl;

            await _usuarioTarefasOficialRepository.UpdateAsync(tarefaUsuario);
        }

        //Remover tarefa da lista do usuário
        public async Task RemoverTarefaAsync(string usuarioId, string tarefaOficialId)
        {
            var tarefaUsuario = await _usuarioTarefasOficialRepository.GetByUsuarioETarefaAsync(usuarioId, tarefaOficialId);
            if (tarefaUsuario == null)
                throw new Exception("Tarefa não encontrada na lista do usuário.");

            await _usuarioTarefasOficialRepository.DeleteAsync(tarefaUsuario);
        }


        //Get de todas tarefas
        public async Task<List<UsuarioTarefasOficiais>> GetTarefasPorUsuarioAsync(string usuarioId)
        {
            return await _usuarioTarefasOficialRepository.GetByUsuarioAsync(usuarioId);
        }
        //Get tarefa por Id
        public async Task<UsuarioTarefasOficiais?> GetTarefaPorUsuarioETarefaAsync(string usuarioId, string tarefaOficialId)
        {
            return await _usuarioTarefasOficialRepository.GetByUsuarioETarefaAsync(usuarioId, tarefaOficialId);
        }


    }
}
