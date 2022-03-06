using Custo0.Contexts;
using Custo0.Domains;
using Custo0.Interfaces;
using Custo0.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly Cust0Context ctx = new();

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

        public Empresa BuscarPorIdUser(int? id)
        {
            return ctx.Empresas.FirstOrDefault(p => p.IdUsuario == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            novaEmpresa.IdUsuarioNavigation.Senha = Cripto.GerarHash(novaEmpresa.IdUsuarioNavigation.Senha);

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

        public void SalvarPerfilDir(IFormFile foto, int id_empresa)
        {

            string nome_novo = id_empresa.ToString() + ".png";
            string caminho = "Assets/perfil/" + nome_novo;


            using (var stream = new FileStream(Path.Combine(caminho), FileMode.Create))
            {
                foto.CopyTo(stream);
            }

            Empresa empresaAtualizado = new();

            Empresa empresaBuscado = BuscarPorId(id_empresa);


            if (empresaAtualizado.ImagemEmpresa != null)
            {
                empresaBuscado.ImagemEmpresa = empresaAtualizado.ImagemEmpresa;
            }


            ctx.Empresas.Update(empresaBuscado);

            ctx.SaveChanges();
        }

        public string ConsultarPerfilDir(int id_usuario)
        {
            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = Path.Combine("Assets/perfil", nome_novo);

            if (File.Exists(caminho))
            {

                byte[] bytesArquivo = File.ReadAllBytes(caminho);

                return Convert.ToBase64String(bytesArquivo);
            }

            return null;

        }
    }
}
