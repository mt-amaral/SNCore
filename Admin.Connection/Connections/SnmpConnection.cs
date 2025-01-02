using ConnectionsControl.ConnectionLibrary.Interfaces;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using System.Net;
using Lextm.SharpSnmpLib.Security;

namespace ConnectionsControl.ConnectionLibrary.Connections;


public class SnmpConnection : ISnmpConnection
{

    public IList<Variable> PerformOperation(string ipv4, int port, string community, string oid, VersionCode version)
    {
        try
        {
            var communityTarget = new OctetString(community);
            var variables = new List<Variable> { new Variable(new ObjectIdentifier(oid)) };

            var result = Messenger.Get(version, new IPEndPoint(IPAddress.Parse(ipv4), port), communityTarget, variables, 6000);
            return  result;
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
            ;
        }
        ;
    }
    
    public List<Variable> WalkOperation(string ipv4, int port, string community, string oid, VersionCode version)
    {
        var result = new List<Variable>();
        try
        {

            var test = Messenger.BulkWalk(version, 
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

}



