using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Domains;

namespace WebApiWsTower.Interfaces
{
    /// <summary>
    /// Interface responsável pelo JogadorRepository
    /// </summary>
    interface IJogadorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeJogador"></param>
        /// <returns></returns>
        List<Jogador> BuscarPorNome(string nomeJogador);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomeSelecao"></param>
        /// <returns></returns>
        List<Jogador> BuscarPorSelecao(string nomeSelecao);
    }
}
