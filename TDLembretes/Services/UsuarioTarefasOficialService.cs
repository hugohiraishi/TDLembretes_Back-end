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

        //FALTA ACABAR AQUI :)

    }
}
