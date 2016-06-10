namespace Delegates
{
    internal class Logger
    {
        public Logger()
        {
        }

        public void WriteMessage(string message)
        {

            System.Console.WriteLine(message);
        }
    }
}