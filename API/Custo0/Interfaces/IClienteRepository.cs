using Custo0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    public interface IClienteRepository
    {
        /// <summary>
        /// Lista todos os clientes
        /// </summary>
        /// <returns>Uma lista de clientes</returns>
        List<Cliente> Listar();


        /// <summary>
        /// Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente que será cadastrado</param>
        void Cadastrar(Cliente novoCliente);

        /// <summary>
        /// Atualiza um cliente existente
        /// </summary>
        /// <param name="id">ID do cliente que será atualizado</param>
        /// <param name="clienteAtualizado">Objeto com as novas informações</param>
        void Atualizar(int id, Cliente clienteAtualizado);

        /// <summary>
        /// Deleta um cliente existente
        /// </summary>
        /// <param name="id">ID do cliente que será deletado</param>
        void Deletar(int id);

        /// <summary>
        /// Busca um cliente através do ID
        /// </summary>
        /// <param name="id">ID do cliente que será buscado</param>
        /// <returns>Um cliente buscado</returns>
        Cliente BuscarPorId(int id);
    }
}
