using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;
using TestMultipleBackends;

namespace SQLServerBackend
{
    [Cmdlet(VerbsCommunications.Connect, "SQLServer", DefaultParameterSetName = "WindowsAuth")]
    [OutputType(typeof(ISQLProvider))]
    public class ConnectSQLServerCommand : Cmdlet
    {
        [Parameter(Mandatory = true, ParameterSetName = "WindowsAuth")]
        [Parameter(Mandatory = true, ParameterSetName = "SQLAuth")]
        [ValidateNotNullOrEmpty]
        public String Server { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "WindowsAuth")]
        [Parameter(Mandatory = true, ParameterSetName = "SQLAuth")]
        [ValidateNotNullOrEmpty]
        public String Instance { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "WindowsAuth")]
        [Parameter(Mandatory = true, ParameterSetName = "SQLAuth")]
        [ValidateNotNullOrEmpty]
        public String Database { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "SQLAuth")]
        [ValidateNotNullOrEmpty]
        public String UserID { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = "SQLAuth")]
        [ValidateNotNullOrEmpty]
        public String Password { get; set; }

        public SQLServerProvider Connection { get; private set; }

        protected override void BeginProcessing()
        {
            Connection = String.IsNullOrEmpty(UserID)
                ? new SQLServerProvider($"Server={Server}\\{Instance};Database={Database};Integrated Security=true;") // kudos: https://stackoverflow.com/a/41126640
                : new SQLServerProvider($"Server={Server}\\{Instance};Database={Database};User Id={UserID};Password={Password};");
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
