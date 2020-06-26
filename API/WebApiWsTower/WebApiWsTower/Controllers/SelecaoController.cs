using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiWsTower.Domains;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Repositories;

namespace WebApiWsTower.Controllers
{
    /// <summary>
    /// Controller responsável pelo endpoint referentes a Seleção
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class SelecaoController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _selecaoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private ISelecaoRepository _selecaoRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public SelecaoController()
        {
            _selecaoRepository = new SelecaoRepository();
        }

        /// <summary>
        /// Lista todas as Seleções
        /// </summary>
        /// <returns> Uma lista de Seleções </returns>
        [HttpGet]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Get()
        {
            try
            {
                // Retora a resposta da requisição 200 - OK fazendo a chamada para o método e trazendo a lista
                return Ok(_selecaoRepository.Listar());
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
