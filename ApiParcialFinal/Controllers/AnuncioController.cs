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
    public class AnuncioController : ApiController
    {
        // GET: api/Anuncio
        public List<AnuncioModel> Get()
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                List<AnuncioModel> listBranch = new List<AnuncioModel>();
                SqlCommand cmd = new SqlCommand("selectAnuncio", oConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listBranch.Add(new AnuncioModel()
                            {
                                idAnuncio = Convert.ToInt32(dr["idAnuncio"]),
                                nombre = (dr["nombre"]).ToString(),
                                precio = Convert.ToDouble(dr["precio"]),
                                descripcion = (dr["descripcion"]).ToString(),
                                ubicacion = (dr["ubicacion"]).ToString(),
                                categoriaN = (dr["categoriaN"]).ToString(),
                                categoria = Convert.ToInt32(dr["categoria"]),
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                usuarioN = (dr["usuarioN"]).ToString(),
                                active = Convert.ToInt32(dr["active"])
                            });
                        }
                    }
                    oConnection.Close();
                    return listBranch;
                }
                catch (Exception ex)
                {

                    return listBranch;
                }

            }
        }

        // GET: api/Anuncio/5
        public AnuncioModel Get(int id)
        {
            using (SqlConnection oConnection = new SqlConnection(ConnectionController.rutaConexion))
            {
                AnuncioModel listBranch = new AnuncioModel();
                SqlCommand cmd = new SqlCommand("selectAnuncioById", oConnection);
                cmd.Parameters.AddWithValue("@idAnuncio", id);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConnection.Open();
                    cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            listBranch.idAnuncio = Convert.ToInt32(dr["idAnuncio"]);
                            listBranch.nombre = (dr["nombre"]).ToString();
                            listBranch.precio = Convert.ToDouble(dr["precio"]);
                            listBranch.descripcion = (dr["descripcion"]).ToString();
                            listBranch.ubicacion = (dr["ubicacion"]).ToString();
                            listBranch.categoriaN = (dr["categoriaN"]).ToString();
                            listBranch.categoria = Convert.ToInt32(dr["categoria"]);
                            listBranch.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                            listBranch.usuarioN = (dr["usuarioN"]).ToString();
                            listBranch.active = Convert.ToInt32(dr["active"]);

                        }
                    }
                    oConnection.Close();
                    return listBranch;
                }
                catch (Exception ex)
                {

                    return listBranch;
                }

            }

        }

        // POST: api/Anuncio
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Anuncio/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Anuncio/5
        public void Delete(int id)
        {
        }
    }
}
