using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            //IEnumerable<string> query = names
            //  .Where(n => n.Contains("a"))
            //  .OrderBy(n => n.Length)
            //  .Select(n => n.ToUpper());
            //foreach (string name in query)
            //    Console.Write(name + "|");
            //Console.ReadKey();

            //string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
            //IEnumerable<int> query = names.Select(n => n.Length);
            //foreach (int length in query)
            //    Console.Write(length);       // 34543
            //Console.ReadKey();

            //Deferred Execution:
            //var numbers = new List<int>();
            //numbers.Add(1);
            //// Build query
            //IEnumerable<int> query = numbers.Select(n => n * 10);
            //numbers.Add(2);    // Sneak in an extra element
            //foreach (int n in query)
            //    Console.Write(n + "|");          // 10|20|
            //Console.ReadKey();

            //Reevaluation:
            //var numbers = new List<int>() { 1, 2 };
            //IEnumerable<int> query = numbers.Select(n => n * 10);
            //foreach (int n in query)
            //    Console.Write(n + "|");   // 10|20|
            //numbers.Clear();
            //foreach (int n in query)
            //    Console.Write(n + "|");   // <nothing>
            //Console.ReadKey();


            var numbers = new List<int>() { 1, 2 };
            List<int> timesTen = numbers
              .Select(n => n * 10)
              .ToList(); // Executes immediately into a List<int>
            Console.WriteLine(timesTen.Count); // Still 2
            numbers.Clear();
            Console.WriteLine(timesTen.Count); // Still 2
            Console.ReadKey();

        }
    }
}
