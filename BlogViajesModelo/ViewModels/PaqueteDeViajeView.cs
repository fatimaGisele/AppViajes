using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogViajesModelo.ViewModels
{
    public class PaqueteDeViajeView
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es requerido")]
        public string Nombre {  get; set; } = string.Empty;
        [Required(ErrorMessage = "El tipo es requerido")]
        public string Tipo { get; set; } = null!;
        [Required(ErrorMessage = "El detalle o descripcion es obligatorio")]
        public string Detalle { get; set; } = null!;
        [Range(1, 1000, ErrorMessage = "Debe indicar una disponibilidad válida")]
        public int Disponibilidad { get; set; }
        public int CantidadDias { get; set; }
        public double Precio {  get; set; }

        [Required(ErrorMessage = "Debe seleccionar al menos un destino")]
        public List<DestinoView> DestinosSeleccionados { get; set; } = new List<DestinoView>();

        public List<SelectListItem> DestinosDisponibles { get; set; } = new();
    }
}
