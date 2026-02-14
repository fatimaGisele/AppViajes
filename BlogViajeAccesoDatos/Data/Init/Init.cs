using BlogViajes.Data;
using BlogViajesModelo;
using BlogViajesUtil;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Init
{
    public class Init : IInit
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Cliente> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public Init(ApplicationDbContext context, UserManager<Cliente> userManager, 
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public void Inicializar()
        {
            try{
                if (_context.Database.GetPendingMigrations().Count()>0)
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex) {
            }

            if (_context.Roles.Any(r=>r.Name==Constant.Administrador)) return;

            _roleManager.CreateAsync(new IdentityRole(Constant.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(Constant.UsuarioSimple)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new Cliente
            {
                UserName = "pichiLinda@gmail.com.ar",
                Email = "pichiLinda@gmail.com.ar",
                PhoneNumber="1234567",
                EmailConfirmed = true,
                Nombre = "pichu",
                Apellido = "altamirano",

            },"Morci031022!").GetAwaiter().GetResult();

            Cliente c = _context.Cliente.Where(c => c.Email == "pichiLinda@gmail.com.ar").FirstOrDefault();

            _userManager.AddToRoleAsync(c, Constant.Administrador).GetAwaiter().GetResult();

        }
    }
}
