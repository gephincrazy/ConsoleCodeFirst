using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LINQSample
{
    class Program
    {
        static void PrintInConsole(IEnumerable<String> query)
        {
            foreach (String tempString in query)
                Console.WriteLine(tempString);
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };

            //IEnumerable<string> query = names
            //  .Where(n => n.Contains("a"))
            //  .OrderBy(n => n.Length)
            //  .Select(n => n.ToUpper());
            //foreach (string name in query)
            //    Console.Write(name + "|");
            //Console.ReadKey();

            #region IEnumberable<T>
            //IEnumerable<int> query = names.Select(n => n.Length);
            //foreach (int length in query)
            //    Console.Write(length);       // 34543
            //Console.ReadKey(); 
            #endregion

            #region Deferred Execution
            //var numbers = new List<int>();
            //numbers.Add(1);
            //// Build query
            //IEnumerable<int> query = numbers.Select(n => n * 10);
            //numbers.Add(2);    // Sneak in an extra element
            //foreach (int n in query)
            //    Console.Write(n + "|");          // 10|20|
            //Console.ReadKey(); 
            #endregion

            #region Reevaluation
            //var numbers = new List<int>() { 1, 2 };
            //IEnumerable<int> query = numbers.Select(n => n * 10);
            //foreach (int n in query)
            //    Console.Write(n + "|");   // 10|20|
            //numbers.Clear();
            //foreach (int n in query)
            //    Console.Write(n + "|");   // <nothing>
            //Console.ReadKey(); 
            #endregion


            #region .Select().ToList()
            //var numbers = new List<int>() { 1, 2 };
            //List<int> timesTen = numbers
            //  .Select(n => n * 10)
            //  .ToList(); // Executes immediately into a List<int>
            //Console.WriteLine(timesTen.Count); // Still 2
            //numbers.Clear();
            //Console.WriteLine(timesTen.Count); // Still 2
            //Console.ReadKey(); 
            #endregion

            #region Variables
            //IEnumerable<char> query = "Not what you might expect";
            //foreach (char vowel in "aeiou")
            //{
            //    char temp = vowel;
            //    query = query.Where(c => c != temp);
            //}
            //foreach (char outs in query)
            //{
            //    Console.Write(outs);

            //}
            //Console.ReadKey(); 
            #endregion

            #region Progressive Query Building
            //var filtered = names.Where(n => n.Contains("a"));
            //var sorted = filtered.OrderBy(n => n);
            //var query = sorted.Select(n => n.ToUpper());
            //foreach (string s in query)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadKey(); 
            #endregion

            #region Translating directly to comprehension syntax
            //IEnumerable<string> query =
            //  from n in names
            //  where n.Length > 2
            //  orderby n
            //  select Regex.Replace(n, "[aeiou]", "");
            //foreach (string s in query)
            //{
            //    Console.WriteLine(s);
            //}
            //Console.ReadKey();
            #endregion

            #region The into keyword lets you "continue" a query after a projection, and is a shortcut for progressively querying.
            //IEnumerable<string> query =
            //  from n in names
            //  select Regex.Replace(n, "[aeiou]", "")
            //      into noVowel
            //      where noVowel.Length > 2
            //      orderby noVowel
            //      select noVowel;
            //PrintInConsole(query);
            #endregion

            #region subquery
            //IEnumerable<string> outerQuery = names
            //  .Where(n => n.Length == names.OrderBy(n2 => n2.Length)
            //          .Select(n2 => n2.Length).First()
            //  );
            //PrintInConsole(outerQuery);
            #endregion

            #region three ways of subquery
            //IEnumerable<string> query =
            //    from n in names
            //    select Regex.Replace(n, "[aeiou]", "");
            //query = from n in query
            //        where n.Length > 2
            //        orderby n
            //        select n;
            //PrintInConsole(query);

            //IEnumerable<string> query2 =
            //  from n1 in
            //      (
            //        from n2 in names
            //        select Regex.Replace(n2, "[aeiou]", "")
            //      )
            //  where n1.Length > 2
            //  orderby n1
            //  select n1;
            //PrintInConsole(query2);

            //IEnumerable<string> query3 = names
            //  .Select(n => Regex.Replace(n, "[aeiou]", ""))
            //  .Where(n => n.Length > 2)
            //  .OrderBy(n => n);
            //PrintInConsole(query3); 
            #endregion

            #region let keyword
            //IEnumerable<string> query =
            //  from n in names
            //  let vowelless = Regex.Replace(n, "[aeiou]", "")
            //  where vowelless.Length > 2
            //  orderby vowelless
            //  select n;     // Thanks to let, n is still in scope.
            //PrintInConsole(query); 
            #endregion
        }
    }
}
