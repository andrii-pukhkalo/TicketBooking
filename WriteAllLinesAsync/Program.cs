using System;
using System.IO;
using System.Threading.Tasks;

namespace WriteAllLinesAsync
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadAllLines.ExampleAsync().GetAwaiter().GetResult();
            //WriteAllLines.ExampleAsync().GetAwaiter().GetResult();
        }
    }

    public class WriteAllLines
    {
        public static async Task ExampleAsync()
        {
            string[] lines =
            {
            "First line", "Second line", "Third line"
        };

            await File.WriteAllLinesAsync("WriteLines.json", lines);
        }
    }

    public class ReadAllLines
    {
        public static async Task ExampleAsync()
        {
            string[] lines = await File.ReadAllLinesAsync("WriteLines.txt");
        }
    }
}
