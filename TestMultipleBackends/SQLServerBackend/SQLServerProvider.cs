using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultipleBackends;

namespace SQLServerBackend
{
    public class SQLServerProvider : ISQLProvider
    {
        private SqlConnection SqlConnection { get; }
        private String TableName { get; set; }

        public SQLServerProvider(String connectionString)
        {
            SqlConnection = new SqlConnection(connectionString);
            SqlConnection.Open();
        }

        internal void Close()
        {
            SqlConnection.Close();
        }

        public void CreateTable(string name)
        {
            TableName = name;
            var command = new SqlCommand($"CREATE TABLE [dbo].[{TableName}] (name [varchar](15), description [varchar](50));", SqlConnection);
            command.ExecuteNonQuery();
        }

        public void CreateRecord(string name, string description)
        {
            var command = new SqlCommand($"INSERT INTO [dbo].[{TableName}] VALUES(@name, @description);", SqlConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
            command.ExecuteNonQuery();
        }
    }
}
