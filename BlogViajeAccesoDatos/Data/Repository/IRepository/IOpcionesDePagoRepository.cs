using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IOpcionesDePagoRepository : IRepository<OpcionesDePago>
    {
        public void Update(OpcionesDePago entity);
    }
}
