using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IPaqueteOpcionesPagoRepository : IRepository<PaqueteOpcionesPago>
    {
        public void Update(PaqueteOpcionesPago paqueteOpcionesPago);
    }
}
