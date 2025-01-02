using Lextm.SharpSnmpLib;

namespace ConnectionsControl.ConnectionLibrary.Interfaces;

public interface ISnmpConnection
{
    IList<Variable> PerformOperation(string ipv4, int port, string community, string oid, VersionCode version);
    void DiscoveryOperation(string ipv4, int port);
}
