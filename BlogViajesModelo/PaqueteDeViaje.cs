using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogViajesModelo
{
    public class PaqueteDeViaje
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tipo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El detalle o descripcion es obligatorio")]
        public string Detalle { get; set; } = null!;
        [Required(ErrorMessage = "La cantidad de dias es obligatoria")]
        public int CantidadDias { get; set; }
        [Range(1, 1000, ErrorMessage = "Debe indicar una disponibilidad válida")]
        public int Disponibilidad { get; set; }
        public double Precio {  get; set; } 
        public virtual ICollection<ViajeDestino> Destino { get; set; } = new List<ViajeDestino>();
        public virtual ICollection<Carrito> Carritos { get; } = new List<Carrito>();
        public virtual ICollection<PaqueteOpcionesPago> OpcionesPagos { get; } = new List<PaqueteOpcionesPago>();

    }
}
