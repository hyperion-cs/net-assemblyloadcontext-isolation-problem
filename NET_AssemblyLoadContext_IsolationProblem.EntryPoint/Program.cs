using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NET_AssemblyLoadContext_IsolationProblem.LibBase;

namespace NET_AssemblyLoadContext_IsolationProblem.EntryPoint;

public class Program
{
    public static void Main()
    {
        var serviceProvider = new ServiceCollection()
            .AddLogging()
            .BuildServiceProvider();

        var libLogger = serviceProvider.GetRequiredService<ILogger<ILib>>();

        var extPath = Path.Combine("libext", "NET_AssemblyLoadContext_IsolationProblem.Lib.dll");
        var loadContext = new ProblemLoadContext(extPath);

        var assem =  loadContext.LoadFromAssemblyName(
            new AssemblyName(Path.GetFileNameWithoutExtension(extPath))
        );

        var type = assem.GetTypes().First(x => x.Name == "LibClass");
        var inst = (ILib)Activator.CreateInstance(type);

        inst.DoSomething(libLogger);

        Console.WriteLine("Done.");
    }
}
