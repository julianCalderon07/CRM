using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CRM.Models
{
    public class ConnectionDB
    {
        #region Variables privadas de clase

        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly SqlConnection conexion;

        /// <summary>
        /// Lista de parámetros para el procedimiento almacenado.
        /// </summary>
        private readonly List<SqlParameter> listParameters;

        #endregion Variables privadas de clase

        public ConnectionDB()
        {
            try
            {
                this.listParameters = new List<SqlParameter>();
                this.conexion = new SqlConnection("server=DESKTOP-K0CJDE3\\HBS;Integrated Security=false;Database=CRM;uid=admin;pwd=D4t4B4s3@dmin;");
                this.conexion.Open();
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "ConnectionDB. " + ex.Message);
            }
        }

        public void AddParameter(String Nombre, object Valor, ParameterDirection Direccion = ParameterDirection.Input, String NombreTipo = "")
        {
            SqlParameter Parameter = new SqlParameter
            {
                ParameterName = "@" + Nombre,
                Value = Valor,
                Direction = Direccion
            };

            if (Valor != null && Valor.GetType().Equals(typeof(DataTable)))
            {
                Parameter.SqlDbType = SqlDbType.Structured;
            }

            if (!string.IsNullOrWhiteSpace(NombreTipo))
            {
                Parameter.TypeName = NombreTipo;
            }
            this.listParameters.Add(Parameter);
        }

        public DataTable Consultar(String sSQL)
        {
            #region Variables de método

            DataTable dt;
            SqlCommand cmd;
            SqlDataReader dr;

            #endregion Variables de método

            try
            {
                dt = new DataTable();
                cmd = new SqlCommand(sSQL, this.conexion);
                dr = cmd.ExecuteReader();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "Consultar. " + ex.Message);
            }
            return dt;
        }

        public Boolean Desconectar()
        {
            try
            {
                this.conexion?.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "Desconectar. " + ex.Message);
            }
        }

        public DataSet EjecutarProcedimiento(String NombreProcedimiento)
        {
            #region Variables de método

            DataSet ds;

            #endregion Variables de método

            ds = new DataSet();

            try
            {
                SqlCommand comando = new SqlCommand
                {
                    Connection = this.conexion,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = NombreProcedimiento,
                    CommandTimeout = 900
                };
                foreach (SqlParameter parameter in this.listParameters)
                {
                    if (parameter.SqlDbType.Equals(SqlDbType.Structured))
                    {
                        comando.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);
                    }
                    else
                    {
                        comando.Parameters.Add(parameter);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter
                {
                    SelectCommand = comando
                };
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "EjecutarProcedimiento. " + ex.Message);
            }
            finally
            {
                this.Desconectar();
                this.listParameters.Clear();
            }
            return ds;
        }
    }
}