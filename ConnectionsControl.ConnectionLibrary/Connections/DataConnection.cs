
using System.Collections.Generic;
using System.Net;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using Lextm.SharpSnmpLib.Security;
using ConnectionsControl.ConnectionLibrary.Interfaces;

namespace ConnectionsControl.ConnectionLibrary.Connections;

public class DataConnection : IDataConnection
{
    public IList<Variable> PerformSnmpOperation(string ipv4, int port, string community, string oid)
    {
        IPAddress agentIp = IPAddress.Parse(ipv4); 
        IPEndPoint endpoint = new IPEndPoint(agentIp, port);

        OctetString communityTarget = new OctetString(community);

        List<Variable> variables = new List<Variable>
        {
            new Variable(new ObjectIdentifier(oid))
        };

        IList<Variable> result = Messenger.Get(VersionCode.V1, endpoint, communityTarget, variables, 6000);

        return result;
    }
}
