using senai_wishlist_webapi.Contexts;
using senai_wishlist_webapi.Domains;
using senai_wishlist_webapi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webapi.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();
        public void cadastrarDesejos(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);
            ctx.SaveChanges();
        }

        public List<Desejo> listarDesejos()
        {
            return ctx.Desejos
                .Select(d => new Desejo
                {
                    IdDesejo = d.IdDesejo,
                    IdUsuario = d.IdUsuario,
                    Titulo = d.Titulo,
                    Descricao = d.Descricao,
                    IdUsuarioNavigation = new Usuario()
                    {
                        Email = d.IdUsuarioNavigation.Email
                    }
                })
                .ToList();
        }
    }
}
