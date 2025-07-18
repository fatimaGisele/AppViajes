using BlogViajes.Data;
using BlogViajesAccesoDatos.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository
{
    public class ContainerT : IContainerT
    {
        private readonly ApplicationDbContext _context;
        public ICarritoRepository carrito { get; private set; }
        public ICarritoDetalleRepository carritoDetalle { get; private set; }
        public ICompraDetalleRepository compraDetalle { get; private set; }
        public IClienteRepository clienteRepository { get; private set; }
        public IDestinoRepository destinoRepository { get; private set; }
        public ICompraRepository compraRepository { get; private set; }
        public IOpcionesDePagoRepository OpcionesDePagoRepository { get; private set; }
        public IPaqueteDeViajeRepository paqueteDeViajeRepository { get; private set; }
        public IPaqueteOpcionesPagoRepository PaqueteOpcionesPagoRepository { get; private set; }
        public IViajeDestinoRepository viajeDestinoRepository { get; private set; }
        public ISliderRepository sliderRepository { get; private set; }

        

        public ContainerT(ApplicationDbContext context) 
        {
            _context = context;
            carrito = new CarritoRepository(_context);
            carritoDetalle = new CarritoDetalleRepository(_context);
            compraDetalle = new CompraDetalleRepository(_context);
            clienteRepository = new ClienteRepository(_context);
            destinoRepository = new DestinoRepository(_context);
            compraRepository = new CompraRepository(_context);
            OpcionesDePagoRepository= new OpcionesDePagoRepository(_context);
            paqueteDeViajeRepository = new PaqueteDeViajeRepository(_context);
            PaqueteOpcionesPagoRepository = new PaqueteOpcionesPagoRepository(_context);
            viajeDestinoRepository = new ViajeDestinoRepository(_context);
            sliderRepository = new SliderRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose(); //libera recursos de la db
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
