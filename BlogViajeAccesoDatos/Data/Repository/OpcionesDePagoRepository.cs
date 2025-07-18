using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using BlogViajesModelo;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class OpcionesDePagoRepository : Repository<OpcionesDePago>, IOpcionesDePagoRepository
    {
        private readonly ApplicationDbContext _context;

        public OpcionesDePagoRepository(ApplicationDbContext c):base(c)
        {
            _context = c;
        }

        public void Update(OpcionesDePago odp)
        {
            var opciones = _context.OpcionesDePagos.FirstOrDefault(i=>i.Id==odp.Id);
            if (opciones != null)
            {
                opciones.Tipo = odp.Tipo;
                opciones.Descripcion = odp.Descripcion;

                _context.SaveChanges();
            }
        }
    }
}
