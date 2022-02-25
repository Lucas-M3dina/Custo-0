using Custo0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    // empresa e instituicao estao repetidos de proposito pq n sei como vao ser chamados no bd
    interface IEmpresaRepository
    {
        /// <summary>
        /// Lista todos as empresas
        /// </summary>
        /// <returns>Uma lista de empresas</returns>
        List<Empresa> Listar();

        /// <summary>
        /// Cadastra uma nova empresa
        /// </summary>
        /// <param name="novaEmpresa">Objeto novaEmpresa que será cadastrado</param>
        void Cadastrar(Empresa novaEmpresa);

        /// <summary>
        /// Atualiza uma empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será atualizado</param>
        /// <param name="empresaAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Empresa empresaAtualizado);

        /// <summary>
        /// Deleta um empresa existente
        /// </summary>
        /// <param name="id">ID da empresa que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um empresa através do ID
        /// </summary>
        /// <param name="id">ID da empresa que será buscada</param>
        /// <returns>Uma empresa buscada</returns>
        Empresa BuscarPorId(int id);
    }
}
