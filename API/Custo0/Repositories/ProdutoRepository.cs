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
    public class ProdutoRepository : IProdutoRepository
    {
        Cust0Context ctx = new Cust0Context();

        public void Atualizar(int id, Produto produtoAtualizado)
        {
            Produto produtoBuscado = BuscarPorId(id);

            if (produtoAtualizado.Preco != null)
            {
                produtoBuscado.Preco = produtoAtualizado.Preco;
            }
            if (produtoAtualizado.Quantidade != null)
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
            return ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).ToList();
        }

        public List<Produto> ListarCategoria(int idCategoria)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarInstituicao(int idInstituicao)
        {
            return ctx.Produtos.Include(C => C.IdEmpresaNavigation).Include(C => C.IdTipoProdutoNavigation).Where(c => c.IdEmpresa == idInstituicao).ToList();
        }
    }
}
