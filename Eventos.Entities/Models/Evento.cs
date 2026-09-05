using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eventos.Entities.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        public required string Nombre { get; set; }

        public DateTime Fecha { get; set; }

        public required string Lugar { get; set; }
    }
}
