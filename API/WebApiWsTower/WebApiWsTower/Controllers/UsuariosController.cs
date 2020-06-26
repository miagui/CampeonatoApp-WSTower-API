using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using WebApiWsTower.Domains;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Repositories;

namespace WebApiWsTower.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos Usuários
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Busca um Usuário pelo ID
        /// </summary>
        /// <param name="id"> ID do Usuário que será buscado </param>
        /// <returns> O Usuário buscado </returns>
        /// <response code="200">OK</response>
        /// <response code="400">Dados inválidos.</response>
        /// <response code="404">Não encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                // Verifica se o Usuário foi encontrado
                if (usuarioBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o Usuário que foi encontrado
                    return Ok(usuarioBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum Usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Cadastra um novo Usuário no sistema
        /// </summary>
        /// <param name="novoUsuario"> Objeto com as informações de Cadastro </param>
        /// <returns> Status code 201 - Created</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public IActionResult Post(Usuario novoUsuario)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.Cadastrar(novoUsuario);

                // Retora a resposta da requisição 201 - Created
                return StatusCode(201);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Altera a Senha de Usuário Exemplo: {{URL}}api/Usuarios/2esenha=1234
        /// </summary>
        /// <param name="id"> ID do Usuário que será buscado </param>
        /// <param name="senha"> Senha que passará a ser a nova senha do Usuário </param>
        /// <returns> OK </returns>
        [HttpPut("{id}&senha={senha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Put(int id, string senha)
        {
            try
            {
                // Faz a chamada para o método
                _usuarioRepository.AlterarSenha(id, senha);

                // Retora a resposta da requisição Ok
                return Ok();
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Altera um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será atualizado </param>
        /// <param name="usuarioAtualizado"> Objeto com as novas informações </param>
        /// <returns>Status code 204 - No Content </returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto usuarioBuscado
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                // Verifica se o usuário foi encontrado
                if (usuarioBuscado != null)
                {
                    // Faz a chamada para o método
                    _usuarioRepository.Atualizar(id, usuarioAtualizado);

                    // Retora a resposta da requisição 204 - No Content
                    return StatusCode(204);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum Usuário encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
