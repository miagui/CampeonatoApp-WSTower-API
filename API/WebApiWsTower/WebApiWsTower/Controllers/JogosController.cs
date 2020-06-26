using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWsTower.Domains;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Repositories;

namespace WebApiWsTower.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes aos Jogos
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Route("api/[controller]")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Produces("application/json")]

    // Define que é um controlador de API
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _jogoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        IJogoRepository _jogoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        /// <summary>
        /// Busca um Jogo pelo ID
        /// </summary>
        /// <param name="id"> ID do Jogo que será buscado </param>
        /// <returns> O Jogo buscado </returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            try
            {
                // Faz a chamada para o método e armazena em um objeto jogoBuscado
                Jogo jogoBuscado = _jogoRepository.BuscarPorId(id);

                // Verifica se o Jogo foi encontrado
                if (jogoBuscado != null)
                {
                    // Retora a resposta da requisição 200 - OK e o Jogo que foi encontrado
                    return Ok(jogoBuscado);
                }

                // Retorna a resposta da requisição 404 - Not Found com uma mensagem
                return NotFound("Nenhum Jogo encontrado para o ID informado");
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Jogo pela Data Exemplo: {{URL}}api/Jogos/Data/2020-04-10
        /// </summary>
        /// <param name="data"> A Data pelo qual o Jogo vai ser buscado </param>
        /// <returns> O Jogo pela data buscada </returns>
        [HttpGet("Data/{data}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListarPorData(DateTime data)
        {
            try
            {
                // Retorna a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo o Jogo pela Data buscada
                return Ok(_jogoRepository.ListarPorData(data));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Jogo pelo Estádio
        /// </summary>
        /// <param name="estadio"> Nome do Estádio pelo qual o Jogo vai ser buscado </param>
        /// <returns> O Jogo com o Estádio buscado </returns>
        [HttpGet("Estadios/{estadio}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListarPorEstadios(string estadio)
        {
            try
            {
                // Retorna a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo o Jogo pelo Estádio buscado
                return Ok(_jogoRepository.ListarPorEstadios(estadio));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }

        /// <summary>
        /// Busca um Jogo pela Seleção
        /// </summary>
        /// <param name="buscaSelecao"> Nome da Seleção que será buscada </param>
        /// <returns> O Jogo pela Seleção buscada </returns>
        [HttpGet("Selecoes/{buscaSelecao}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ListarPorSelecao(string buscaSelecao)
        {
            try
            {
                // Retorna a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo o Jogo pela Seleção buscada
                return Ok(_jogoRepository.ListarPorSelecao(buscaSelecao));
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
