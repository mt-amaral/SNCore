using Lextm.SharpSnmpLib;

namespace Admin.Connection.Interfaces;

public interface ISnmpConnection
{
    Variable PerformOperation(string ipv4, int port, string community, string oid, VersionCode version);
    List<Variable> WalkOperation(string ipv4, int port, string community, string oid, VersionCode version);
    void DiscoveryOperation(string ipv4, int port);
}
