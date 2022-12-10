using ApiParcialFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiParcialFinal.Controllers
{
    public class PostulacionController : ApiController
    {
        // GET: api/Postulacion
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Postulacion/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Postulacion
        public Exception Post([FromBody]PostulacionModel value)
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                PostulacionModel branch = new PostulacionModel();
                SqlCommand cmd = new SqlCommand("createPostulacion", oConnection);
                cmd.Parameters.AddWithValue("@idUsuario", value.idUsuario);
                cmd.Parameters.AddWithValue("@referencias", value.referencias);
                cmd.Parameters.AddWithValue("@DUI", value.DUI);
                cmd.Parameters.AddWithValue("@solvenciaPNC", value.solvenciaPNC);
                cmd.Parameters.AddWithValue("@antecedentes", value.antecedentes);
                cmd.Parameters.AddWithValue("@idAnuncio", value.idAnuncio);
                cmd.Parameters.AddWithValue("@estado", value.estado);
                cmd.Parameters.AddWithValue("@active", value.active);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    Exception e = new Exception();
                    return e;
                }
                catch (Exception ex)
                {

                    return ex;
                }

            }
        }

        // PUT: api/Postulacion/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Postulacion/5
        public void Delete(int id)
        {
        }
    }
}
