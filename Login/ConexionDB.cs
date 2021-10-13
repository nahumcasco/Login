using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Login
{
    public class ConexionDB
    {
        readonly string cadena = "Data Source=192.168.1.28;Initial Catalog=Login;User ID=sa;Password=Estado2012";

        public bool ValidarUsuario(Usuario user)
        {
            bool esUsuarioValido = false;

            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT 1 FROM USUARIO WHERE USUARIO = @User AND CLAVE = @Clave; ");

                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@User", SqlDbType.NVarChar, 50).Value = user.CodigoUsuario;
                        comando.Parameters.Add("@Clave", SqlDbType.NVarChar, 50).Value = user.Clave;
                        esUsuarioValido = Convert.ToBoolean(comando.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            {

            }
            return esUsuarioValido;
        }


        public bool InsertarProducto(Producto producto)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO PRODUCTO ");
                sql.Append(" VALUES (@Descripcion, @Precio, @Existencia); ");


                string sentenciaSQL = "INSERT INTO PRODUCTO VALUES (@Descripcion, @Precio, @Existencia);";

                using (SqlConnection _conexion = new SqlConnection(cadena))
                {
                    _conexion.Open();
                    using (SqlCommand comando = new SqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar, 80).Value = producto.Descripcion;
                        comando.Parameters.Add("@Precio", SqlDbType.Decimal).Value = producto.Precio;
                        comando.Parameters.Add("@Existencia", SqlDbType.Int).Value = producto.Existencia;

                        comando.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
