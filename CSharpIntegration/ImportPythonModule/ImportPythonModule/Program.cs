using System;
using IronPython.Hosting;

namespace ImportPythonModule
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();

            var searchPaths = engine.GetSearchPaths();
            searchPaths.Add("./ScriptPlugins");
            engine.SetSearchPaths(searchPaths);

            var scope = engine.ImportModule("interesting_stuff");

            var printHelloWorldFunction = scope.GetVariable("print_hello_world");
            printHelloWorldFunction();

            var printMessageFunction = scope.GetVariable("print_message");
            printMessageFunction("Goodbye!");

            var addFunction = scope.GetVariable("add");
            Console.WriteLine($"The sum of 1 and 2 is {addFunction(1, 2)}.");
        }
    }
}