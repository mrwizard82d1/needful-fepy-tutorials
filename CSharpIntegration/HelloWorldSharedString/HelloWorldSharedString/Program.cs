using System;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace HelloWorldSharedString
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();
            var source = engine.CreateScriptSourceFromString(@"
hello_world_string = 'Hello, IronPython Shared World!'
print(hello_world_string)
print(shared_text)"
                );

            // Create a scope (Python namespace) for shared variables.
            var scope = engine.CreateScope();
            
            // Add a shored variable.
            scope.SetVariable("shared_text", "How do you do?");

            DumpScope("Before execution", scope);

            // Execute the script in the scope (namespace) with the shared variable.
            source.Execute(scope);

            DumpScope("After execution", scope);

            Console.WriteLine($"Get `hello_world_string`: {scope.GetVariable("hello_world_string")}");
            Console.WriteLine($"Get `shared_text`: {scope.GetVariable("shared_text")}");
        }

        private static void DumpScope(string prefix, ScriptScope scope)
        {
            Console.WriteLine();
            Console.WriteLine(prefix);

            foreach (var name in scope.GetVariableNames())
            {
                Console.WriteLine($"  {name}={scope.GetVariable(name)}");
            }
            
            Console.WriteLine();
        }
    }
}