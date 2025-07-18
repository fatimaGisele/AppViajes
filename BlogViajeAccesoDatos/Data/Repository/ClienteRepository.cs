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
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public void BloquearUser(string userId)
        {
            var user = _context.Cliente.FirstOrDefault(u=>u.Id==userId);
            user.LockoutEnd = DateTime.Now.AddYears(100);
             _context.SaveChanges();
        }

        public void DesbloquearUser(string userId)
        {
            var user = _context.Cliente.FirstOrDefault(u => u.Id == userId);
            user.LockoutEnd = DateTime.Now;
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            var clienteActualizado = _context.Cliente.FirstOrDefault(i=>i.Id==cliente.Id);
            if (clienteActualizado != null)
            {
                clienteActualizado.Nombre = cliente.Nombre;
                clienteActualizado.Apellido = cliente.Apellido;
                clienteActualizado.Email = cliente.Email;

                _context.SaveChanges();
            }

        }
    }
}
