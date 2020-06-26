using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWsTower.Domains;
using WebApiWsTower.Enum;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Repositories;
using WebApiWsTower.ViewModels;

namespace WebApiWsTower.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes ao Login
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o Usuário
        /// </summary>
        /// <param name="login"> Objeto login que contém o e-mail e a senha do usuário </param>
        /// <returns> Retorna uma mensagem de Sucesso ou Inválido </returns>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult Post(LoginViewModel login)
        {
            int resultado = _usuarioRepository.ValidarLogin(login.Usuario, login.Senha);

            if (resultado == (int)Message.SUCESSO) return Ok("Sucesso");
            else if (resultado == (int)Message.SENHA_INVALIDA) return NotFound("Senha Inválida");
            else if (resultado == (int)Message.USUARIO_INVALIDO) return NotFound("Usuário Inválido");
            return NotFound();
        }
    }
}
