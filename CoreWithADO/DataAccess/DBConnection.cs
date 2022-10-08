using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using CoreWithADO.Models;
namespace CoreWithADO.DataAccess
{
    public class DBConnection
    {
        public SqlConnection sql { get; }
        public DBConnection()
        {
            sql = new SqlConnection(ConnectionStr.Connection);
        }
    }
}
