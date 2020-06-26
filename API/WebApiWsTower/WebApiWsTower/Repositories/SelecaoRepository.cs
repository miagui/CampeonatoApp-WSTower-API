using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Contexts;
using WebApiWsTower.Domains;
using WebApiWsTower.Interfaces;
using WebApiWsTower.Models;

namespace WebApiWsTower.Repositories
{
    /// <summary>
    /// Repositório responsável pelas Seleções
    /// </summary>
    public class SelecaoRepository : ISelecaoRepository
    {
        // Objeto contexto por onde serão chamados os método do Entity Framework Core
        CampeonatoContext ctx = new CampeonatoContext();

        /// <summary>
        /// Lista as informações das Seleções
        /// </summary>
        /// <returns> Uma lista de Seleções</returns>
        public List<SelecaoPontos> Listar()
        {
            // Include adiciona o uso de navigation.
            // AsNoTracking é usado para evitar que crie uma respota JSON grande demais (>50mb).
            List<Selecao> selecoes = ctx.Selecao.Include(Selecao => Selecao.Jogador).AsNoTracking().ToList();
            return CalcularPontos(selecoes);
        }

        public List<SelecaoPontos> CalcularPontos(List<Selecao> selecoes)
        {
            List<SelecaoPontos> ranking = new List<SelecaoPontos>();
            List<Jogo> jogos = ctx.Jogo.ToList();

            foreach (Selecao s in selecoes)
            {
                int pontos = 0;

                foreach (Jogo j in jogos)
                {
                    if (j.SelecaoCasa == s.Id)
                    {
                        // Se a seleção ganhou esse jogo...
                        if (j.PlacarCasa > j.PlacarVisitante) pontos =+ 3;
                        // Se a seleção empatou nesse jogo...
                        else if (j.PlacarCasa == j.PlacarVisitante) pontos =+ 1;
                    }

                    if (j.SelecaoVisitante == s.Id)
                    {
                        // Se a seleção ganhou esse jogo...
                        if (j.PlacarVisitante > j.PlacarCasa) pontos =+ 3;
                        // Se a seleção empatou nesse jogo...
                        else if (j.PlacarVisitante == j.PlacarCasa) pontos =+ 1;
                    }
                }

                ranking.Add(new SelecaoPontos
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    Bandeira = s.Bandeira,
                    Escalacao = s.Escalacao,
                    Uniforme = s.Uniforme,
                    TotalPontos = pontos,
                    Jogador = s.Jogador
                });
            }

            return ranking;
        }
    }
}
