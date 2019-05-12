/*
 * ADO.NET is the technology for building Data Centric Apps in .NET
 * It has primarly 2 types of data access: Connected and Disconnected Model. 
 * Connected Model is used for desktop centric Apps and Disconnected Model is used for Web centric Applications. 
 * System.Data.SqlClient is the namespace that contains classes for dataprogramming on SQL server. However U have other namespaces for different kinds of databases.
 * Connected Model: Connection, Command and Reader.
 * Connection is the class used to connect to the database using Open and Close methods...
 * Command is used to execute the SQL Commands to the connected database. 
 * If the Command is a select statement, U need a Reader which is used to read the data. Reader is a readonly object. 
 * U dont need a reader object for insertion, deletion and updation. 
 */
using System;
using System.Data.SqlClient;
namespace SampleConApp
{
    class DBProgram
    {
        const string strCon = @"Data Source =.\SQLEXPRESS;Initial Catalog = CDACTraining; Integrated Security = True";
        static void Main()
        {
            //readRecords();
            //findRecord("Phaniraj");
            insertRecord(4,"Rahul","Chennai","56000");
        }

        private static void insertRecord(int id, string name, string address, string sal)
        {
            string statement = $"INSERT INTO EMPTABLE VALUES({id},'{name}','{address}',{sal})";
            var con = new SqlConnection(strCon);
            var cmd = new SqlCommand(statement, con);
            try
            {
                con.Open();
                var rowsAffected = cmd.ExecuteNonQuery();//use ExecuteNonQuery to insert, delete, update......
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private static void findRecord(string v)
        {
            //create the connection
            SqlConnection con = new SqlConnection(strCon);//consts are all static...
            //create the command
            SqlCommand cmd = new SqlCommand($"SELECT * FROM EMPTABLE WHERE EMPNAME = '{v}'", con);
            //open the connection
            try
            {
                con.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"The Name:{reader["EmpName"]}\nAddress:{reader[2]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message) ;
            }
            finally
            {
                con.Close();
            }
            //execute the command
            //read the data
            //finally close
        }

        private static void readRecords()
        {
            //create the connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=CDACTraining;Integrated Security=True";
            //create the Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;//Association...
            cmd.CommandText = "SELECT * FROM EMPTABLE";
            try
            {
                con.Open();//Opens the connection to the database...
                SqlDataReader reader = cmd.ExecuteReader();//Executes the Query and returns a Reader object
                while (reader.Read())
                {
                    Console.WriteLine($"The Name:{reader["EmpName"]}\nAddress:{reader[2]}");
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
            //execute the command
            //read the data
            //close the connection..
        }
    }
}