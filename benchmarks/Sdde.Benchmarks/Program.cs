// See https://aka.ms/new-console-template for more information
using System.Reflection;
using BenchmarkDotNet.Running;

// BenchmarkRunner.Run<JsonBenchmarks>();
// BenchmarkSwitcher.FromAssembly(Assembly.GetExecutingAssembly()).Run(args);


try
{
    BenchmarkSwitcher
        // .FromAssembly(typeof(Program).Assembly)
        .FromAssembly(Assembly.GetExecutingAssembly())
        .Run(args);

    return 0;
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(ex.Message);
    Console.ResetColor();
    return 1;
}
