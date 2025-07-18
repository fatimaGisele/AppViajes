using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class DestinoRepository : Repository<Destino>, IDestinoRepository
    {
        private readonly ApplicationDbContext _context;

        public DestinoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Destino destino)
        {
            var d = _context.Destino.Find(destino.Id);

            if (d != null)
            {
                d.NombreDestino = destino.NombreDestino;
                d.Precio = destino.Precio;

                _context.SaveChanges();
            }
        }
    }
}
