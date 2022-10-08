using CoreWithADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Data;
using System.Data;
namespace CoreWithADO.DataAccess
{
    public class EmployeeAccessDb
    {
        DBConnection DB = new DBConnection();

        public List<Employees> GetEmployees()
        {
            string sp = "sp_get_employees";
            SqlCommand command = new SqlCommand(sp,DB.sql);
            command.CommandType =CommandType.StoredProcedure;
            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            List<Employees> lstemployees = new List<Employees>();
            while(reader.Read())
            {
                Employees em = new Employees();
                em.id =(int)reader["Id"];
                em.fname = reader["Fname"].ToString();
                em.lname = reader["Lname"].ToString();
                em.email = reader["Email"].ToString();
                em.salary = reader["Salary"].ToString();
                em.mobile = reader["Mobile"].ToString();
                em.gender = reader["Gender"].ToString();

                lstemployees.Add(em);
            }

            DB.sql.Close();
            return lstemployees;

        }

        public  void CreateEmployee(Employees emp)
        {
            string sp = "sp_create_employee";
            SqlCommand command = new SqlCommand(sp, DB.sql);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@action", "insert");
            command.Parameters.AddWithValue("@fname", emp.fname);
            command.Parameters.AddWithValue("@lname", emp.lname);
            command.Parameters.AddWithValue("@email", emp.email);
            command.Parameters.AddWithValue("@salary", emp.salary);
            command.Parameters.AddWithValue("@mobile", emp.mobile);
            command.Parameters.AddWithValue("@gender", emp.gender);

            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            DB.sql.Close();
        }

        public void UpdateEmployee(Employees emp)
        {
            string sp = "sp_create_employee";
            SqlCommand command = new SqlCommand(sp, DB.sql);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@action", "update");
            command.Parameters.AddWithValue("@id", emp.id);
            command.Parameters.AddWithValue("@fname", emp.fname);
            command.Parameters.AddWithValue("@lname", emp.lname);
            command.Parameters.AddWithValue("@email", emp.email);
            command.Parameters.AddWithValue("@salary", emp.salary);
            command.Parameters.AddWithValue("@mobile", emp.mobile);
            command.Parameters.AddWithValue("@gender", emp.gender);

            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            DB.sql.Close();
        } 
        
        public void DeleteEmployee(int id)
        {
            string sp = "sp_create_employee";
            SqlCommand command = new SqlCommand(sp, DB.sql);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@action", "delete");
            command.Parameters.AddWithValue("@id",id);
            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            DB.sql.Close();
        }


        public Employees GetEmployee(int id)
        {
            string sp = "sp_create_employee";
            SqlCommand command = new SqlCommand(sp, DB.sql);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@action", "get_single");
            command.Parameters.AddWithValue("@id", id);
            if (DB.sql.State == ConnectionState.Closed)
            {
                DB.sql.Open();
            }
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            Employees em = new Employees();
            em.id = (int)reader["Id"];
            em.fname = reader["Fname"].ToString();
            em.lname = reader["Lname"].ToString();
            em.email = reader["Email"].ToString();
            em.salary = reader["Salary"].ToString();
            em.mobile = reader["Mobile"].ToString();
            em.gender = reader["Gender"].ToString();
            DB.sql.Close();
            return em;
        }

    }
}
