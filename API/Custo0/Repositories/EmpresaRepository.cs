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
    public class EmpresaRepository : IEmpresaRepository
    {
        Cust0Context ctx = new Cust0Context();

        public void Atualizar(int id, Empresa empresaAtualizado)
        {
            Empresa empresaBuscada = BuscarPorId(id);

            if (empresaAtualizado.IdEndereco != null)
            {
                empresaBuscada.IdEndereco = empresaAtualizado.IdEndereco;
            }
            if (empresaAtualizado.NomeFantasia != null)
            {
                empresaBuscada.NomeFantasia = empresaAtualizado.NomeFantasia;
            }
            if (empresaAtualizado.Cnpj != null)
            {
                empresaBuscada.Cnpj = empresaAtualizado.Cnpj;
            }
            if (empresaAtualizado.ImagemEmpresa != null)
            {
                empresaBuscada.ImagemEmpresa = empresaAtualizado.ImagemEmpresa;
            }

            ctx.Empresas.Update(empresaBuscada);

            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresas.FirstOrDefault(p => p.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresas.Add(novaEmpresa);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresaBuscado = BuscarPorId(id);

            ctx.Empresas.Remove(empresaBuscado);

            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresas.Include(C => C.IdEnderecoNavigation).ToList();
        }
    }
}
