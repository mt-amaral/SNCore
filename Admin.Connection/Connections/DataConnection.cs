using ConnectionsControl.ConnectionLibrary.Interfaces;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;

namespace ConnectionsControl.ConnectionLibrary.Connections;


public class DataConnection : IDataConnection
{

    public List<string> PerformSnmpOperation(string ipv4, int port, string community, string oid)
    {
        var endpoint = new IPEndPoint(IPAddress.Parse(ipv4), port);
        var communityTarget = new OctetString(community);
        var variables = new List<Variable> { new Variable(new ObjectIdentifier(oid)) };

        var result = Messenger.Get(VersionCode.V1, endpoint, communityTarget, variables, 6000);

        return result.Select(data => data.ToString()).ToList();
    }

}
