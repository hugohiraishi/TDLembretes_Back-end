using System.Security.Claims;
using TDLembretes.Repositories;
using TDLembretes.Models;

namespace TDLembretes.Services
{
    public class AuthService
    {

        private readonly AuthRepository _authRepository;
        private readonly TokenService _tokenService;
        private readonly UsuarioService _usuarioService;

        public AuthService(AuthRepository authRepository, TokenService tokenService, UsuarioService usuarioService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
            _usuarioService = usuarioService;
        }

        public async Task<string> SignIn(string email, string senha)
        {
            Usuario usuario = await GetUsuarioByEmailAndSenha(email, senha);
            string token = _tokenService.CreateToken(usuario);

            return token;
        }


        public async Task<string> Register(string nome, string email, string senha, string telefone)
        {

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
                throw new Exception("Nome, e-mail e senha são obrigatórios.");

            Usuario? usuario = await _authRepository.GetUsuarioByEmail(email);
            if (usuario != null)
            {
                throw new Exception("E-mail já cadastrado!");
            }

            Usuario novoUsuario = new Usuario(
                Guid.NewGuid().ToString(),
                nome,
                email,
                senha,
                0,
                telefone,
                new List<UsuarioTarefasOficiais>()
                );

             await _authRepository.AddUsuario(novoUsuario);

            return novoUsuario.Id;
        }


        private async Task<Usuario> GetUsuarioByEmailAndSenha(string email, string senha)
        {
            Usuario? usuario = await _authRepository.GetUsuarioByEmailAndSenha(email, senha);
            if (usuario == null)
            {
                throw new Exception("Usuario e/ou senha inválidos! ");
            }

            return usuario;
        }

        public string GetAuthenticatedUserId(ClaimsPrincipal User)
        {
            string? userId = User.Claims.First(p => p.Type == "id")?.Value;
            if (userId == null)
            {
                throw new Exception("User not found on token JWT");
            }

            return userId;
        }

        public async Task<Usuario?> AutenticarUsuario(string email, string senha)
        {
            var usuario = await _authRepository.GetUsuarioByEmailAndSenha(email, senha);
            return usuario;
        }

        }



    }

