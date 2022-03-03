using Custo0.Contexts;
using Custo0.Domains;
using Custo0.Interfaces;
using Custo0.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Cust0Context ctx = new();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(id);

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return ctx.Usuarios.FirstOrDefault(p => p.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {

            novoUsuario.Senha = Cripto.GerarHash(novoUsuario.Senha);

            ctx.Usuarios.Add(novoUsuario);            
        }

        public void Deletar(int id)
        {
            Usuario UsuarioBuscado = BuscarPorId(id);

            ctx.Usuarios.Remove(UsuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.Include(C => C.IdTipoUsuarioNavigation).ToList();
        }

        public Usuario Login(string email, string password)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                if (usuario.Senha == password)
                {
                    usuario.Senha = Cripto.GerarHash(usuario.Senha);

                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

                bool comparado = Cripto.CompararSenha(password, usuario.Senha);

                if (comparado) return usuario;
            }
            return null;
        }
    }
}
