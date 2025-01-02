
using ConnectionsControl.ConnectionLibrary.Connections;
using Lextm.SharpSnmpLib;
using Xunit;

namespace Connection.Test;


public class SnmpTeste
{

    private string ipv4 = "192.168.77.249";
    private int port = 161;
    private string communityKey = "public";
    SnmpConnection snmpConnection = new SnmpConnection();


    [Fact]
    public void MakesPerformSnmpOperation()
    {
        string oid = ".1.3.6.1.2.1.25.2.3.1.5.65536";
        try
        {
           var result = snmpConnection.PerformOperation(ipv4, port, communityKey, oid, VersionCode.V2);
        }
        catch (Exception ex)
        {
            ;
        }
    }
    
    [Fact]
    public void DiscoverySnmpOperation_MakesRealSnmpRequest()
    {
        string ipv4 = "192.168.77.249";
        int port = 161;   
        

        snmpConnection.DiscoveryOperation(ipv4, port);
    }
    
    [Fact]
    public void MakesWalkOperation()
    {
        string oid = ".1.3.6.1.2.1.2.2.1.2";

        string ipv4 = "192.168.77.249";
        int port = 161;   
        
        snmpConnection.WalkOperation(ipv4, port, communityKey, oid, VersionCode.V2);
    }
    
    
}
