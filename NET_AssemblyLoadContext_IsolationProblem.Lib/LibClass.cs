using System;
using Microsoft.Extensions.Logging;
using NET_AssemblyLoadContext_IsolationProblem.LibBase;

// To reproduce the bug, you only need to import a third-party nuget package that has similar dependencies to the parent project (EntryPoint).
using Csla;

namespace NET_AssemblyLoadContext_IsolationProblem.Lib
{
    public class LibClass : ILib
    {
        private ILogger _logger;

        public void DoSomething(object logger)
        {
            _logger = (Logger<ILib>)logger; // Type casting is important to get the correct error.
            Console.WriteLine($"{nameof(LibClass)}: I did something!");
        }
    }
}
