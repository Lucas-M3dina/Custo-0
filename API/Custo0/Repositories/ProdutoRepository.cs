using Custo0.Contexts;
using Custo0.Domains;
using Custo0.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly Cust0Context ctx = new();

        public void Atualizar(int id, Produto produtoAtualizado)
        {
            Produto produtoBuscado = BuscarPorId(id);

            if (produtoAtualizado.Preco != 0)
            {
                produtoBuscado.Preco = produtoAtualizado.Preco;
            }
            if (produtoAtualizado.Quantidade != 0)
            {
                produtoBuscado.Quantidade = produtoAtualizado.Quantidade;
            }
            if (produtoAtualizado.Promocao != null)
            {
                produtoBuscado.Promocao = produtoAtualizado.Promocao;
            }
            if (produtoAtualizado.Descricao != null)
            {
                produtoBuscado.Descricao = produtoAtualizado.Descricao;
            }
            if (produtoAtualizado.ImagemProduto != null)
            {
                produtoBuscado.ImagemProduto = produtoAtualizado.ImagemProduto;
            }
            if (produtoAtualizado.DataValidade != null)
            {
                produtoBuscado.DataValidade = produtoAtualizado.DataValidade;
            }

            ctx.Produtos.Update(produtoBuscado);

            ctx.SaveChanges();
        }

        public Produto BuscarPorId(int id)
        {
            return ctx.Produtos.FirstOrDefault(p => p.IdProduto == id);
        }

        public void Cadastrar(Produto novoProduto)
        {
            ctx.Produtos.Add(novoProduto);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Produto produtosBuscado = BuscarPorId(id);

            ctx.Produtos.Remove(produtosBuscado);

            ctx.SaveChanges();
        }

        public List<Produto> Listar()
        {
            DateTime now = DateTime.Now;

            List<Produto> produtos = ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).Where(c => c.DataValidade > now).ToList();

            foreach (Produto p in produtos)
            {
                Deletar(p.IdProduto);
            }

            return ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).ToList();
        }

        public List<Produto> ListarCategoria(int idCategoria)
        {
            return ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).Where(c => c.IdTipoProduto == idCategoria).ToList();

        }

        public List<Produto> ListarInstituicao(int idInstituicao)
        {
            return ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).Where(c => c.IdEmpresa == idInstituicao).ToList();
        }

        public void SalvarPerfilDir(IFormFile foto, int id_usuario)
        {

            string nome_novo = id_usuario.ToString() + ".png";
            string caminho = "Assets/produto/" + nome_novo ;


            using (var stream = new FileStream(Path.Combine(caminho), FileMode.Create))
            {
                foto.CopyTo(stream);
            }

            Produto produtoAtualizado = new();

            Produto produtoBuscado = BuscarPorId(id_usuario);

           
            if (produtoAtualizado.ImagemProduto != null)
            {
                produtoBuscado.ImagemProduto = produtoAtualizado.ImagemProduto;
            }
           

            ctx.Produtos.Update(produtoBuscado);

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
