using Admin.Connection.Interfaces;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;

namespace Admin.Connection.Connections;


public class SnmpConnection : ISnmpConnection
{

    public Variable PerformOperation(string ipv4, int port, string community, string oid, VersionCode version)
    {
        try
        {
            OctetString communityTarget = new OctetString(community);
            List<Variable> variables = new List<Variable> { new Variable(new ObjectIdentifier(oid)) };

            var result = Messenger.Get(version, new IPEndPoint(IPAddress.Parse(ipv4), port), communityTarget, variables, 6000);
            return result[0];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    public List<Variable> WalkOperation(string ipv4, int port, string community, string oid, VersionCode version)
    {
        var result = new List<Variable>();
        try
        {

            int response = Messenger.BulkWalk(version,
                            new IPEndPoint(IPAddress.Parse(ipv4), port),
                            new OctetString(community),
                            OctetString.Empty,
                            new ObjectIdentifier(oid),
                            result,
                            60000,
                            1,
                            WalkMode.WithinSubtree,
                            null,
                            null);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public void DiscoveryOperation(string ipv4, int port)
    {
        try
        {
            Discovery discovery = Messenger.GetNextDiscovery(SnmpType.GetRequestPdu);
            ReportMessage report = discovery.GetResponse(60000, new IPEndPoint(IPAddress.Parse(ipv4), port));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}



