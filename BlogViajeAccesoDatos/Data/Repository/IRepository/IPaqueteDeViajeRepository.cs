using BlogViajesModelo;
using BlogViajesModelo.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IPaqueteDeViajeRepository :  IRepository<PaqueteDeViaje>
    {
        public void Update(PaqueteDeViajeView paqueteDeViaje);
        public void CrearNuevoPaquete(PaqueteDeViajeView paquete);
        public void UpdateDisponibilidad(int paqueteId, int nuevaDisponibilidad);
        
    }
}
