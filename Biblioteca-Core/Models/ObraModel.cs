using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca_Core.Models
{
    public class ObraModel
    {
        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Editora { get; set; }

        public string Foto { get; set; }

        public string Autores { get; set; }
    }
}
