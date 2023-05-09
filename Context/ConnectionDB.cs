using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CRM.Models
{
    public class ConnectionDB
    {
        #region Variables privadas de clase

        /// <summary>
        /// Lista de parámetros para el procedimiento almacenado.
        /// </summary>
        private readonly List<SqlParameter> _listParameters;

        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        private readonly SqlConnection _sqlConnection;

        #endregion Variables privadas de clase

        public ConnectionDB()
        {
            try
            {
                _listParameters = new List<SqlParameter>();
                _sqlConnection = new SqlConnection("server=DESKTOP-K0CJDE3\\HBS;Integrated Security=false;Database=CRM;uid=admin;pwd=D4t4B4s3@dmin;");
                _sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "ConnectionDB. " + ex.Message);
            }
        }

        public void AddParameter(String Nombre, object Valor, ParameterDirection Direccion = ParameterDirection.Input, String NombreTipo = "")
        {
            SqlParameter Parameter = new()
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
            _listParameters.Add(Parameter);
        }

        public async Task<Boolean> Desconectar()
        {
            try
            {
                await _sqlConnection.CloseAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "Desconectar. " + ex.Message);
            }
        }

        public async Task<DataSet> ExecuteProcedure(String NombreProcedimiento)
        {
            #region Variables de método

            DataSet ds;

            #endregion Variables de método

            ds = new DataSet();

            try
            {
                SqlCommand comando = new()
                {
                    Connection = _sqlConnection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = NombreProcedimiento,
                    CommandTimeout = 900
                };
                foreach (SqlParameter parameter in _listParameters)
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
                SqlDataAdapter da = new()
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
                await Desconectar();
                _listParameters.Clear();
            }
            return ds;
        }

        public async Task<DataTable> ExecuteQuery(String sSQL)
        {
            #region Variables de método

            DataTable dt;
            SqlCommand cmd;
            SqlDataReader dr;

            #endregion Variables de método

            try
            {
                dt = new DataTable();
                cmd = new SqlCommand(sSQL, _sqlConnection);
                dr = await cmd.ExecuteReaderAsync();
                dt.Load(dr);
            }
            catch (Exception ex)
            {
                throw new ExternalException("ConnectionDB. " + "Consultar. " + ex.Message);
            }
            return dt;
        }
    }
}