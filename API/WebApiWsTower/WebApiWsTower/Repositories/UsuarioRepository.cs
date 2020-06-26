using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Contexts;
using WebApiWsTower.Domains;
using WebApiWsTower.Enum;
using WebApiWsTower.Interfaces;

namespace WebApiWsTower.Repositories
{
    /// <summary>
    /// Repositório responsável pelos Usuários
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        CampeonatoContext ctx = new CampeonatoContext();

        public void AlterarSenha(int id, string senha)
        {
            Usuario usuarioBuscado = ctx.Usuario

            .FirstOrDefault(u => u.Id == id);

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Senha = senha;

                ctx.SaveChanges();
            }            
        }

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = ctx.Usuario.Find(id);

            if (usuarioBuscado != null)
            {
                if (usuarioAtualizado.Nome != null)
                {
                    usuarioBuscado.Nome = usuarioAtualizado.Nome;
                }

                if (usuarioAtualizado.Email != null)
                {
                    usuarioBuscado.Email = usuarioAtualizado.Email;
                }

                if (usuarioAtualizado.Apelido != null)
                {
                    usuarioBuscado.Apelido = usuarioAtualizado.Apelido;
                }

                if (usuarioAtualizado.Foto != null)
                {
                    usuarioBuscado.Foto = usuarioAtualizado.Foto;
                }

                if (usuarioAtualizado.Senha != null)
                {
                    usuarioBuscado.Senha = usuarioAtualizado.Senha;
                }

                ctx.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Id == id);

            // Verifica se o Usuário foi encontrado
            if (usuarioBuscado != null)
            {
                // Retorna o usuario encontrado
                return usuarioBuscado;
            }

            // Caso não seja encontrado, retorna nulo
            return null;
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            // Adiciona um novo Usuário
            ctx.Usuario.Add(novoUsuario);

            // Salva as informações para serem gravadas no Banco
            ctx.SaveChanges();
        }

        // TODO: Testar
        public int ValidarLogin(string usuario, string senha)
        {
            var emailValidator = new EmailAddressAttribute();

            // Se for um email.
            if (emailValidator.IsValid(usuario))
            {
                Usuario u = ctx.Usuario.FirstOrDefault(u => u.Email == usuario);
                if (u != null)
                {
                    if (u.Senha == senha)
                    {
                        // Retorna 2 = Login validado.
                        return (int)Message.SUCESSO;
                    }
                    else
                    {
                        // Retorna 1 = Senha incorreta.
                        return (int)Message.SENHA_INVALIDA;
                    }
                }
                else
                {
                    // Retorna 0 = Email ou apelido não encontrado.
                    return (int)Message.USUARIO_INVALIDO;
                }
            }
            // Se for um apelido.
            else
            {
                Usuario u = ctx.Usuario.FirstOrDefault(u => u.Apelido == usuario);

                if (u != null)
                {
                    if (u.Senha == senha)
                    {
                        // Retorna 2 = Login validado.
                        return (int)Message.SUCESSO;
                    }
                    else
                    {
                        // Retorna 1 = Senha incorreta.
                        return (int)Message.SENHA_INVALIDA;
                    }
                }
                else
                {
                    // Retorna 0 = Email ou apelido não encontrado.
                    return (int)Message.USUARIO_INVALIDO;
                }
            }
        }
    }
}
