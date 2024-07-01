using Lextm.SharpSnmpLib;

namespace ConnectionsControl.ConnectionLibrary.Interfaces;

public interface IDataConnection
{
    IList<Variable> PerformSnmpOperation(string ipv4, int port, string community, string oid);
}
