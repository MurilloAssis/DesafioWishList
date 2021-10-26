using senai_wishlist_webapi.Contexts;
using senai_wishlist_webapi.Domains;
using senai_wishlist_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webapi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();
        public Usuario Login(string Email, string Senha)
        {
            return ctx.Usuarios.FirstOrDefault(e => e.Email == Email && e.Senha == Senha);
        }
    }
}
