using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiParcialFinal.Models
{
    public class UsuariosModel
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string email { get; set; }
        public string pwd { get; set; }
        public string tipoUsuarioN { get; set; }
        public int tipoUsuario { get; set; }
    }
}