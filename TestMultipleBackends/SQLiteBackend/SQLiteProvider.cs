using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMultipleBackends;
using System.Data.SQLite;
using System.Data;

namespace SQLiteBackend
{
    public class SQLiteProvider : ISQLProvider
    {
        private SQLiteConnection SqlConnection { get; }
        private String TableName { get; set; }

        public SQLiteProvider(String connectionString)
        {
            SqlConnection = new SQLiteConnection(connectionString);
            SqlConnection.Open();
        }

        internal void Close()
        {
            SqlConnection.Close();
        }

        public void CreateTable(string name)
        {
            TableName = name;
            var command = new SQLiteCommand($"CREATE TABLE {TableName} (name STRING, description STRING);", SqlConnection);
            command.ExecuteNonQuery();
        }

        public void CreateRecord(string name, string description)
        {
            var command = new SQLiteCommand($"INSERT INTO {TableName} VALUES(@name, @description);", SqlConnection);
            command.Parameters.Add("@name", DbType.String).Value = name;
            command.Parameters.Add("@description", DbType.String).Value = description;
            command.ExecuteNonQuery();
        }
    }
}
