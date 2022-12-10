using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiParcialFinal.Models
{
    public class AnuncioModel
    {
        public int idAnuncio { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public int categoria { get; set; }
        public string categoriaN { get; set; }
        public int active { get; set; }
        public int idUsuario { get; set; }
        public string usuarioN { get; set; }
    }
}