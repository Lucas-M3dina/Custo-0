using Custo0.Contexts;
using Custo0.Domains;
using Custo0.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly Cust0Context ctx = new();

        public Reserva BuscarPorId(int id)
        {
            return ctx.Reservas.FirstOrDefault(p => p.IdReserva == id);
        }

        public void Criar(Reserva novaReserva)
        {
            ctx.Reservas.Add(novaReserva);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Reserva reservasBuscado = BuscarPorId(id);

            ctx.Reservas.Remove(reservasBuscado);

            ctx.SaveChanges();
        }

        public void Editar(int id, Reserva reservaAtualizado)
        {
            Reserva reservaBuscado = BuscarPorId(id);

            if (reservaAtualizado.IdSituacao != null)
            {
                reservaBuscado.IdSituacao = reservaAtualizado.IdSituacao;
            }

            ctx.Reservas.Update(reservaBuscado);

            ctx.SaveChanges();
        }

        public List<Reserva> Listar()
        {
            return ctx.Reservas.Include(C => C.IdClienteNavigation).Include(C => C.IdEmpresaNavigation).Include(C => C.IdProdutoNavigation).ToList();
        }

        public List<Reserva> ListarCliente(int idCliente)
        {
            return ctx.Reservas.Include(C => C.IdClienteNavigation).Include(C => C.IdEmpresaNavigation).Include(C => C.IdProdutoNavigation).Where(c => c.IdCliente == idCliente).ToList();
        }

        public List<Reserva> ListarEmpresa(int idEmpresa)
        {
            return ctx.Reservas.Include(C => C.IdClienteNavigation).Include(C => C.IdEmpresaNavigation).Include(C => C.IdProdutoNavigation).Where(c => c.IdEmpresa == idEmpresa).ToList();
        }

        public List<Reserva> ListarPendentes(int idEmpresa)
        {
            return ctx.Reservas.Include(C => C.IdClienteNavigation).Include(C => C.IdEmpresaNavigation).Include(C => C.IdProdutoNavigation).Where(c => c.IdEmpresa == idEmpresa && c.IdSituacao == 1).ToList();
        }
    }
}
