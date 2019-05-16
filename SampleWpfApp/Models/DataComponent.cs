using System;
using System.Data;
using System.Data.SqlClient;

namespace SampleWinApp.Models
{
    class DataComponent
    {
        const string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=CDACTraining;Integrated Security=True";
        const string strSELECT = "SELECT * FROM EmpTable";
        const string strFind = "SELECT * FROM StudentTable where studentId = @id";
        const string strUpdate = "Update StudentTable set name= @name, address = @address where studentid = @id";
        const string strDelete = "Delete from studenttable where studentid = @id";
        const string strInsert = "Insert into studentTable values(@id, @name, @address)";
        public DataTable GetAllEmployees()
        {
            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand(strSELECT, con);
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;
            }
            catch
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public void AddNewStudent(int id, string name, string address)
        {
            //"Insert into studentTable values(@id, @name, @address)"
            var con = new SqlConnection(strConnection);
            var cmd = new SqlCommand(strInsert, con);
            //insert the parameters for the statement...
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
