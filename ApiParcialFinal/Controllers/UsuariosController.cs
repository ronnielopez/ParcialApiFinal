using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using ApiParcialFinal.Models;
using System.Web.Http;
using ApiParcialFinal.Data;

namespace ApiParcialFinal.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/Usuarios
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Usuarios/5
        public UsuariosModel Get(int id)
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                UsuariosModel branch = new UsuariosModel();
                SqlCommand cmd = new SqlCommand("selectUsuario", oConnection);
                cmd.Parameters.AddWithValue("@idUsuario", id);
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
                    return branch;
                }
                catch (Exception ex)
                {

                    return branch;
                }

            }
        }

        // POST: api/Usuarios
        public Boolean Post([FromBody]UsuariosModel value)
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                SqlCommand cmd = new SqlCommand("createUsuario", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", value.nombre);
                cmd.Parameters.AddWithValue("@email", value.email);
                cmd.Parameters.AddWithValue("@pwd", EncriptarData.Encriptar(value.pwd));
                cmd.Parameters.AddWithValue("@tipoUsuario", value.tipoUsuario);
                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    oConnection.Close();
                    return true;
                }
                catch (Exception ex)
                {

                    return false;
                }

            }
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Usuarios/5
        public void Delete(int id)
        {
        }
    }
}
