using IronPython.Hosting;

namespace HelloWorldStdLib
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();
            var searchPaths = engine.GetSearchPaths();
            searchPaths.Add("./ScriptPlugins");
            engine.SetSearchPaths(searchPaths);

            var source = engine.CreateScriptSourceFromFile("./ScriptPlugins/hello_world_base64.py");
            source.Execute();
        }
    }
}