using Microsoft.AspNetCore.Mvc;
using TDLembretes.Services;
using TDLembretes.DTO;
using TDLembretes.Models;

namespace TDLembretes.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly AuthService _authService;
        private readonly TokenService _tokenService;

        public AuthController(AuthService authService, TokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn([FromBody] SignInUsuarioDTO dto)
        {
            try
            {
                var usuario = await _authService.AutenticarUsuario(dto.Email, dto.Senha);
                if (usuario == null)
                {
                    return Unauthorized(new { message = "Usuário e/ou senha inválidos!" });
                }

                var token = _tokenService.CreateToken(usuario);

                return Ok(new
                {
                    id = usuario.Id,
                    nome = usuario.Nome,
                    email = usuario.Email,
                    telefone = usuario.Telefone,
                    pontos = usuario.Pontos,
                    token = token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("register")]
        public async Task<ActionResult<string>> Register(UsuarioDTO usuarioCadastroDTO)
        {
            try
            {
                var usuario = await _authService.Register(usuarioCadastroDTO.Nome, usuarioCadastroDTO.Email, usuarioCadastroDTO.Senha, usuarioCadastroDTO.Telefone);

                return Ok(new { Message = "Usuário cadastrado com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }

    }

