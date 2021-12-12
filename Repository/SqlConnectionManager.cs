using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PropertiesTask
{
    class SqlConnectionManager
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-FOU7P3Q\\SQLEXPRESS;Database=RealEstate;Trusted_Connection=True;";

        public SqlConnection CreateSqlConnection()
        {
            return new SqlConnection(CONNECTION_STRING);
        }

    }
}
