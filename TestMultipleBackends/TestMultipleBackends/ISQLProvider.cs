using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMultipleBackends
{
    public interface ISQLProvider
    {
        void CreateTable(String name);

        void CreateRecord(String name, String description);
    }
}
