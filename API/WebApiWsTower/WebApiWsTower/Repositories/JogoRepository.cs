using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Contexts;
using WebApiWsTower.Domains;
using WebApiWsTower.Interfaces;

namespace WebApiWsTower.Repositories
{
    /// <summary>
    /// Repositório responsável pelos Jogos
    /// </summary>
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do Entity Framework
        /// </summary>
        CampeonatoContext ctx = new CampeonatoContext(); 

        /// <summary>
        /// Busca um Jogo pelo ID
        /// </summary>
        /// <param name="id"> ID do Jogo que será buscado </param>
        /// <returns> O Jogo buscado </returns>
        public Jogo BuscarPorId(int id)
        {
            return ctx.Jogo.FirstOrDefault(j => j.Id == id);
        }

        public List<Jogo> ListarPorData(DateTime data)
        {
            return ctx.Jogo.Where(j => j.Data == data).ToList();
        }

        public List<Jogo> ListarPorEstadios(string estadio)
        {
            return ctx.Jogo.Where(j => j.Estadio.ToUpper().Contains(estadio.ToUpper())).ToList();
        }

        // TODO: Retorna lista vazia
        public List<Jogo> ListarPorSelecao(string buscaSelecao)
        {
            // Novamente, usa AsNoTracking para evitar Navigations desnecessarios.
            return ctx.Jogo.Include(j => j.SelecaoCasaNavigation)
                .Include(j => j.SelecaoVisitanteNavigation)
                .Where(j => j.SelecaoCasaNavigation.Nome.ToUpper().Contains(buscaSelecao.ToUpper()) ||
                        j.SelecaoVisitanteNavigation.Nome.ToUpper().Contains(buscaSelecao.ToUpper())).AsNoTracking().ToList();
        }
    }
}
