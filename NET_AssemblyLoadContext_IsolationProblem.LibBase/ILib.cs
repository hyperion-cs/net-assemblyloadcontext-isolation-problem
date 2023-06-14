using Microsoft.Extensions.Logging;

namespace NET_AssemblyLoadContext_IsolationProblem.LibBase;

public interface ILib
{
    void DoSomething(object logger);
}
