using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using TestMultipleBackends;

namespace SQLiteBackend
{
    [Cmdlet(VerbsCommunications.Connect, "SQLite")]
    [OutputType(typeof(ISQLProvider))]
    public class ConnectSQLiteCommand : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public String Path { get; set; }

        public SQLiteProvider Connection { get; private set; }

        protected override void BeginProcessing()
        {
            //Connection = new SQLiteProvider($"Data Source={Path}\\MyDb.sqlite;Version=3;");
            Connection = new SQLiteProvider($"Data Source={Path}\\MyDb.sqlite;");
        }

        protected override void ProcessRecord()
        {
            WriteObject(Connection);
        }

        protected override void EndProcessing()
        {
            Connection.Close();
        }
    }
}
