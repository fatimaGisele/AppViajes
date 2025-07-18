using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesAccesoDatos.Data.Repository.IRepository
{
    public interface IContainerT : IDisposable
    {
        //Se agregan los repositorios
        ICarritoRepository carrito { get; }
        ICarritoDetalleRepository carritoDetalle { get; }
        ICompraDetalleRepository compraDetalle { get; }
        IClienteRepository clienteRepository { get; }
        IDestinoRepository destinoRepository { get; }
        ICompraRepository compraRepository { get; }
        IOpcionesDePagoRepository OpcionesDePagoRepository { get; }
        IPaqueteDeViajeRepository paqueteDeViajeRepository { get; }
        IPaqueteOpcionesPagoRepository PaqueteOpcionesPagoRepository { get; }
        IViajeDestinoRepository viajeDestinoRepository { get; }
        ISliderRepository sliderRepository { get; }

        void Save();


    }
}
