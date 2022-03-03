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
    public class ClienteRepository : IClienteRepository
    {
        Cust0Context ctx = new Cust0Context();

        public void Atualizar(int id, Cliente clienteAtualizado)
        {
            Cliente clienteBuscado = BuscarPorId(id);

            if (clienteAtualizado.IdEndereco != null)
            {
                clienteBuscado.IdEndereco = clienteAtualizado.IdEndereco;
            }
            if (clienteAtualizado.Documento != null)
            {
                clienteBuscado.Documento = clienteAtualizado.Documento;
            }
            if (clienteAtualizado.Nome != null)
            {
                clienteBuscado.Nome = clienteAtualizado.Nome;
            }

            ctx.Clientes.Update(clienteBuscado);

            ctx.SaveChanges();
        }

        public Cliente BuscarPorId(int id)
        {
            return ctx.Clientes.FirstOrDefault(p => p.IdCliente == id);
        }

        public void Cadastrar(Cliente novoCliente)
        {
            ctx.Clientes.Add(novoCliente);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteBuscado = BuscarPorId(id);

            ctx.Clientes.Remove(clienteBuscado);

            ctx.SaveChanges();
        }

        public List<Cliente> Listar()
        {
            return ctx.Clientes.Include(C => C.IdEnderecoNavigation).ToList();

        }
    }
}
