using System;
using System.Collections.Generic;
using IronPython.Hosting;

namespace HelloWorldModules
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();
            var beforeSearchPaths = engine.GetSearchPaths();
            DumpSearchPaths("Before search paths", beforeSearchPaths);
            
            beforeSearchPaths.Add("./ScriptPlugins");
            engine.SetSearchPaths(beforeSearchPaths);

            DumpSearchPaths("After search paths", engine.GetSearchPaths());

            var source = engine.CreateScriptSourceFromFile("./hello_world.py");
            source.Execute();
        }

        private static void DumpSearchPaths(string prefix, IEnumerable<string> searchPaths)
        {
            Console.WriteLine(prefix);
            
            foreach (var searchPath in searchPaths)
            {
                Console.WriteLine($"  {searchPath}");
            }

            Console.WriteLine();
        }
    }
}