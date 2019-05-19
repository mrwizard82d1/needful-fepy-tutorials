using IronPython.Hosting;

namespace HelloWorldString
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();
            var script = engine.CreateScriptSourceFromString("print('Hello, IronPython Scripting World!')");
            script.Execute();
        }
    }
}