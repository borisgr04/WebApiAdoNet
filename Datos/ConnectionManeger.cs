using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Datos
{
    public class ConnectionManeger
    {
        internal SqlConnection _conexion;

        public ConnectionManeger(string connectionString)
        {
            _conexion = new SqlConnection(connectionString);
        }

        public void Open()
        {
            _conexion.Open();
        }

        public void Close()
        {
            _conexion.Close();
        }
    }
}
