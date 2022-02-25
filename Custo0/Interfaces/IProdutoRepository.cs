using Custo0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    interface IProdutoRepository
    {
        /// <summary>
        /// Lista todos os produtos
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        List<Produto> Listar();

        /// <summary>
        /// Lista todos os produtos da empresa
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        List<Produto> ListarInsituicao(int idInsituicao);

        /// <summary>
        /// Lista todos os produtos da determinada categoria
        /// </summary>
        /// <returns>Uma lista de produtos</returns>
        List<Produto> ListarCategoria(int idCategoria);

        /// <summary>
        /// Cadastra um novo produto
        /// </summary>
        /// <param name="novoProduto">Objeto novoProduto que será cadastrado</param>
        void Cadastrar(Produto novoProduto);

        /// <summary>
        /// Atualiza um produto existente
        /// </summary>
        /// <param name="id">ID do produto que será atualizado</param>
        /// <param name="usuarioAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Produto produtoAtualizado);

        /// <summary>
        /// Deleta um produto existente
        /// </summary>
        /// <param name="id">ID do produto que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um produto através do ID
        /// </summary>
        /// <param name="id">ID do produto que será buscado</param>
        /// <returns>Um produto buscado</returns>
        Produto BuscarPorId(int id);
    }
}
