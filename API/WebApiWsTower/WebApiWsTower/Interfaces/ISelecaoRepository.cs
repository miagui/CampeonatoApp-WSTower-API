using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Domains;
using WebApiWsTower.Models;

namespace WebApiWsTower.Interfaces
{
    /// <summary>
    /// Interface responsável pelo SelecaoRepository
    /// </summary>
    interface ISelecaoRepository
    {
        /// <summary>
        /// Lista todas as Seleções
        /// </summary>
        /// <returns> Uma lista de Seleções </returns>
        List<SelecaoPontos> Listar();
    }
}
