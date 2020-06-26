using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Domains;

namespace WebApiWsTower.Interfaces
{
    /// <summary>
    /// Interface responsável pelo UsuarioRepository
    /// </summary>
    interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um Usuário pelo ID
        /// </summary>
        /// <param name="id"> ID do Usuário que será buscado</param>
        /// <returns> O Usuário buscado </returns>
        Usuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo Usuário no sistema
        /// </summary>
        /// <param name="novoUsuario"> Objeto com as informações de Cadastro </param>
        void Cadastrar(Usuario novoUsuario);

        /// <summary>
        /// Altera um Usuário existente
        /// </summary>
        /// <param name="id"> ID do Usuário que será atualizado </param>
        /// <param name="usuarioAtualizado"> Objeto com as novas informações </param>
        void Atualizar(int id, Usuario usuarioAtualizado);

        /// <summary>
        /// Alterar a Senha de Usuário
        /// </summary>
        void AlterarSenha(int id, string senha);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        int ValidarLogin(string usuario, string senha);
    }
}
