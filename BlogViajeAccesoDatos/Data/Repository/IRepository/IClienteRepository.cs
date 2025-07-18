using BlogViajesModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public void Update(Cliente cliente);

        void BloquearUser(string userId);
        void DesbloquearUser(string userId);
    }
}
