using ApiParcialFinal.Data;
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
    public class RegisterController : ApiController
    {
        // GET: api/Register
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Register/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Register
        public UsuariosModel Post([FromBody]UsuariosModel value)
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                UsuariosModel branch = new UsuariosModel();
                SqlCommand cmd = new SqlCommand("RegisterUsuario", oConnection);
                cmd.Parameters.AddWithValue("@email", value.email);
                cmd.Parameters.AddWithValue("@nombre", value.nombre);
                cmd.Parameters.AddWithValue("@tipoUsuario", value.tipoUsuario);
                cmd.Parameters.AddWithValue("@pwd", EncriptarData.Encriptar(value.pwd));

                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            branch.email = (dr["email"]).ToString();
                            branch.nombre = (dr["nombre"]).ToString();
                            branch.tipoUsuarioN = (dr["tipoUsuarioN"]).ToString();
                            branch.tipoUsuario = Convert.ToInt32(dr["tipoUsuario"]);
                        }
                    }
                    oConnection.Close();
                    if (branch.email != null)
                    {
                        return branch;
                    }
                    return branch;
                }
                catch (Exception ex)
                {

                    return branch;
                }

            }
        }

        // PUT: api/Register/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Register/5
        public void Delete(int id)
        {
        }
    }
}
