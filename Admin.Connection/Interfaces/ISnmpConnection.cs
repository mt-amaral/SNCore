using Lextm.SharpSnmpLib;

namespace Admin.Connection.Interfaces;

public interface ISnmpConnection
{
    IList<Variable> PerformOperation(string ipv4, int port, string community, string oid, VersionCode version = VersionCode.V2);
    List<Variable> WalkOperation(string ipv4, int port, string community, string oid, VersionCode version = VersionCode.V2);
    void DiscoveryOperation(string ipv4, int port);
}
