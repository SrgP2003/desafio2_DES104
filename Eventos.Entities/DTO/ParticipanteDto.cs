using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Entities.DTO
{
    public class ParticipanteDto
    {
        public int Codigo { get; set; }

        [Required(ErrorMessage = "El nombre del participante es obligatorio.")]
        [StringLength(
            50,
            MinimumLength = 3,
            ErrorMessage = "El nombre del participante debe tener entre 3 y 50 caracteres."
        )]
        public string NombreParticipante { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string CorreoElectronico { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe especificar el evento asociado.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe especificar un evento válido.")]
        public int EventoCodigo { get; set; }
    }
}
