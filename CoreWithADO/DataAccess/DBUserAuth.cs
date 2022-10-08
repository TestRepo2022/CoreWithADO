using CoreWithADO.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWithADO.DataAccess
{
    public class DBUserAuth
    {
        DBConnection DB = new DBConnection();

        public bool RegisterUser(UserSignUp user)
        {
            string sp = "usp_signup";
            SqlCommand command = new SqlCommand(sp, DB.sql);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@name", user.name);
            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@password", user.password);
            command.Parameters.AddWithValue("@mobile", user.mobile);
            command.Parameters.AddWithValue("@gender",  user.gender);
            command.Parameters.AddWithValue("@profile", user.profile);

            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int i =(int)reader[0];
            DB.sql.Close();
            return Convert.ToBoolean(i);
        }

        public bool LoginUser(UserSignIn user)
        {
            string sp = "usp_signin";
            SqlCommand command = new SqlCommand(sp, DB.sql);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@email", user.email);
            command.Parameters.AddWithValue("@password", user.password);
            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            int i = (int)reader[0];
            DB.sql.Close();
            return Convert.ToBoolean(i);
        }
    }
}
