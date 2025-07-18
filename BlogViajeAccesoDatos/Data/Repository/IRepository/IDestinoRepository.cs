using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IDestinoRepository : IRepository<Destino>
    {
        public void Update(Destino destino);
    }
}
