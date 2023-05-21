using System.Data;
using System.Data.SqlClient;
using PruebaTecnicaAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PruebaTecnicaAPI.Data
{
    public class TrabajadorData
    {
        public static Trabajador Registrar(Trabajador oTrabajador)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.routeConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@documentoidentidad", oTrabajador.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", oTrabajador.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oTrabajador.Telefono);
                cmd.Parameters.AddWithValue("@correo", oTrabajador.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oTrabajador.Ciudad);
                SqlParameter outputParam = new SqlParameter("@IdTrabajador", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);
                try
                {
                   oConexion.Open();
                   cmd.ExecuteNonQuery();
       
                   // Obtener el ID del trabajador creado
                   int idTrabajador = (int)outputParam.Value;
       
                   // Obtener el usuario recién registrado
                   Trabajador trabajadorRegistrado = TrabajadorData.Obtener(idTrabajador);
                   return trabajadorRegistrado;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static Trabajador Modificar(int id, Trabajador oTrabajador)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.routeConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);
                cmd.Parameters.AddWithValue("@documentoidentidad", oTrabajador.DocumentoIdentidad);
                cmd.Parameters.AddWithValue("@nombres", oTrabajador.Nombres);
                cmd.Parameters.AddWithValue("@telefono", oTrabajador.Telefono);
                cmd.Parameters.AddWithValue("@correo", oTrabajador.Correo);
                cmd.Parameters.AddWithValue("@ciudad", oTrabajador.Ciudad);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    // Recuperar el usuario editado
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Trabajador trabajador = new Trabajador()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString()
                            };

                            return trabajador;
                        }
                    }

                    return null; // No se encontró el usuario editado
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        public static List<Trabajador> Listar()
    {
        List<Trabajador> oListaTrabajador = new List<Trabajador>();
        using (SqlConnection oConexion = new SqlConnection(Conexion.routeConnection))
        {
            SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Trabajador trabajador = new Trabajador()
                        {
                            IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                            DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                            Nombres = dr["Nombres"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Ciudad = dr["Ciudad"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        };

                        oListaTrabajador.Add(trabajador);
                    }
                }

                return oListaTrabajador;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error: " + ex.Message);
                return oListaTrabajador;
            }
        }
    }


        public static Trabajador Obtener(int idUsuario)
        {
            Console.WriteLine(idUsuario);
            Trabajador oTrabajador = new Trabajador();
            using (SqlConnection oConexion = new SqlConnection(Conexion.routeConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oTrabajador = new Trabajador()
                            {
                                IdUsuario = Convert.ToInt32(dr["idUsuario"]),
                                DocumentoIdentidad = dr["DocumentoIdentidad"].ToString(),
                                Nombres = dr["Nombres"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"].ToString())
                            };
                        }

                    }



                    return oTrabajador;
                }
                catch (Exception ex)
                {
                    return oTrabajador;
                }
            }
        }

        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.routeConnection))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

    }
}