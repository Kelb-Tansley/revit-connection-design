using Models_SC_Proj;
using RevitConnectionProperties.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Revit_eToolKit_Map.Mappers
{
    public class ConnectionType_Mapper
    {
        public static ConnectionType Map_Revit_to_eToolKit_ConnectionType(string rvtConnectionType)
        {
            if (rvtConnectionType == RvtConnectionType.MomentConnection)
            {
                return ConnectionType.MomentConnection;
            }
            else if (rvtConnectionType == RvtConnectionType.BasePlateConnection)
            {
                return ConnectionType.BasePlate;
            }
            else if (rvtConnectionType == RvtConnectionType.SimpleConnection)
            {
                return ConnectionType.SimpleConnection;
            }
            else if (rvtConnectionType == RvtConnectionType.SpliceConnection)
            {
                return ConnectionType.MomentConnection;
            }
            else
            {
                return 0;
            }
        }
    }
}
    

