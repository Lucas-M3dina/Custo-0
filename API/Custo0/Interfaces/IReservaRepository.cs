using Custo0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    interface IReservaRepository
    {
        /// <summary>
        /// Lista todos as reservas
        /// </summary>
        /// <returns>Uma lista de reservas</returns>
        List<Reserva> Listar();

        /// <summary>
        /// Lista todos as reservas do cliente
        /// </summary>
        /// <param name="idCliente">ID do cliente</param>
        /// <returns>Uma lista de reservas</returns>
        List<Reserva> ListarCliente(int idCliente);

        /// <summary>
        /// Lista todos as reservas da instituição
        /// </summary>
        /// <param name="idEmpresa">ID da empresa</param>
        /// <returns>Uma lista de reservas</returns>
        List<Reserva> ListarEmpresa(int idEmpresa);

        /// <summary>
        /// Lista todos as reservas da instituição que precisam de aprovação
        /// </summary>
        /// <param name="idEmpresa">ID da empresa</param>
        /// <returns>Uma lista de reservas</returns>
        List<Reserva> ListarPendentes(int idEmpresa);

        /// <summary>
        /// Cadastra uma nova reserva
        /// </summary>
        /// <param name="novaReserva">Objeto novaReserva que será cadastrado</param>
        void Criar(Reserva novaReserva);

        /// <summary>
        /// Atualiza uma reserva existente
        /// </summary>
        /// <param name="id">ID da reserva que será atualizado</param>
        /// <param name="reservaAtualizado">Objeto com as novas informações</param>
        void Editar(int id, Reserva reservaAtualizado);

        /// <summary>
        /// Deleta uma reserva existente
        /// </summary>
        /// <param name="id">ID da reserva que será deletada</param>
        void Deletar(int id);

        /// <summary>
        /// Busca uma reserva através do ID
        /// </summary>
        /// <param name="id">ID da reserva que será buscada</param>
        /// <returns>Uma reserva buscado</returns>
        Reserva BuscarPorId(int id);
    }
}
