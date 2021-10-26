using senai_wishlist_webapi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_wishlist_webapi.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> listarDesejos();
        void cadastrarDesejos(Desejo novoDesejo);
    }
}
