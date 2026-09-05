using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Entities.DTO
{
    public class OrganizadorDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del organizador es obligatorio.")]
        [StringLength(
            50,
            MinimumLength = 3,
            ErrorMessage = "El nombre del organizador debe tener entre 3 y 50 caracteres."
        )]
        public string NombreOrganizador { get; set; } = string.Empty;

        [Required(ErrorMessage = "El cargo del organizador es obligatorio.")]
        [StringLength(
            50,
            MinimumLength = 3,
            ErrorMessage = "El cargo del organizador debe tener entre 3 y 50 caracteres."
        )]
        public string CargoOrganizador { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar el evento asociado.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe especificar un evento válido.")]
        public int EventoCodigo { get; set; }
    }
}
