using IronPython.Hosting;

namespace HelloWorldFile
{
    public static class Program
    {
        public static void Main()
        {
            var engine = Python.CreateEngine();
            // The original example uses a pathname of `../../HelloWorld.py` because VisualStudio runs the code in the
            // `bin/Debug` or `bin/Release` directories. Rider; however, its its run configuration, sets the current
            // directory to the project directory.
            var source = engine.CreateScriptSourceFromFile("./HelloWorld.py");

            source.Execute();
        }
    }
}