using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    // empresa e instituicao estao repetidos de proposito pq n sei como vao ser chamados no bd
    interface IInstituicaoRepository
    {
        /// <summary>
        /// Lista todos as instituicaos
        /// </summary>
        /// <returns>Uma lista de instituicoes</returns>
        List<Instituicao> Listar();

        /// <summary>
        /// Cadastra uma nova instituicao
        /// </summary>
        /// <param name="novaInstituicao">Objeto novaInstituicao que será cadastrado</param>
        void Cadastrar(Instituicao novaInstituicao);

        /// <summary>
        /// Atualiza uma instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será atualizada</param>
        /// <param name="instituicaoAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Instituicao instituicaoAtualizado);

        /// <summary>
        /// Deleta um instituicao existente
        /// </summary>
        /// <param name="id">ID da instituicao que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um instituicao através do ID
        /// </summary>
        /// <param name="id">ID da instituicao que será buscada</param>
        /// <returns>Uma instituicao buscada</returns>
        Instituicao BuscarPorId(int id);
    }
}
