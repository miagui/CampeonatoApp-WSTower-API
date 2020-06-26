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
    /// Repositório responsável pelos Jogadores
    /// </summary>
    public class JogadorRepository : IJogadorRepository
    {
        // Objeto contexto por onde serão chamados os métodos do Entity Framework
        CampeonatoContext ctx = new CampeonatoContext();

        public List<Jogador> BuscarPorNome(string nomeJogador)
        {
            return ctx.Jogador.Where(j => j.Nome.ToUpper().Contains(nomeJogador.ToUpper())).ToList();
        }

        // TODO: Não retorna a lista de Seleções
        public List<Jogador> BuscarPorSelecao(string nomeSelecao)
        {
            // Include adiciona o uso de navigation.
            // AsNoTracking é usado para evitar que mostre o time de jogador no navigation.
            return ctx.Jogador.Include(j => j.Selecao )
                .Where(j => j.Selecao.Nome.ToUpper().Contains(nomeSelecao.ToUpper())).AsNoTracking().ToList();
        }
    }
}
