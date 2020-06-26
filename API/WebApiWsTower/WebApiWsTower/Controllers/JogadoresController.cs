using Microsoft.AspNetCore.Mvc;
using System;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Repositories;

namespace WebApiWsTower.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos Jogadores
    /// </summary>

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que é um controlador de API
    [ApiController]
    public class JogadoresController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _jogadorRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IJogadorRepository _jogadorRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogadoresController()
        {
            _jogadorRepository = new JogadorRepository();
        }

        /// <summary>
        /// Busca um Jogador pelo Nome ou palavra-chave
        /// </summary>
        /// <param name="nomeJogador"> Nome do Jogador ou palavra-chave que será buscado </param>
        /// <returns> O Jogador ou Jogadores os Jogadores buscados </returns>
        [HttpGet("{nomeJogador}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult BuscarPorNome(string nomeJogador)
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo o Jogador ou Jogadores buscados
                return Ok(_jogadorRepository.BuscarPorNome(nomeJogador));
            } 
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca uma Seleção pelo nome ou palavra-chave
        /// </summary>
        /// <param name="nomeSelecao"> Nome da Seleção ou palavra-chave que será buscada </param>
        /// <returns></returns>
        [HttpGet("Selecoes/{nomeSelecao}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult BuscarPorSelecao(string nomeSelecao)
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a Seleção ou Seleções buscadas
                return Ok(_jogadorRepository.BuscarPorSelecao(nomeSelecao));
            }
            catch ( Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
