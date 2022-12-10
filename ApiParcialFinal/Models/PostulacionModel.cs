using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiParcialFinal.Models
{
    public class PostulacionModel
    {
        public int? idPostulacion { get; set; }
        public int? idUsuario { get; set; }
        public string referencias { get; set; }
        public string DUI { get; set; }
        public int? solvenciaPNC { get; set; }
        public int? antecedentes { get; set; }
        public int? idAnuncio { get; set; }
        public int? estado { get; set; }
        public int? active { get; set; }
    }
}