using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Domains;

namespace WebApiWsTower.Interfaces
{
    /// <summary>
    /// Interface responsável pelo JogoRepository
    /// </summary>
    interface IJogoRepository
    {
        /// <summary>
        /// Busca um Jogo pelo ID
        /// </summary>
        /// <param name="id"> ID do Jogo que será buscado </param>
        /// <returns> O Jogo buscado </returns>
        Jogo BuscarPorId(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buscaSelecao"></param>
        /// <returns></returns>
        List<Jogo> ListarPorSelecao(string buscaSelecao);

        List<Jogo> ListarPorEstadios(string estadio);

        List<Jogo> ListarPorData(DateTime data);
    }
}
