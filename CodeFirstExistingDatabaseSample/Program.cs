using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExistingDatabaseSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }

    public class User
    {
        
        [Key]
        public string WeiXinOpenID { get; set; }
        [Index(IsUnique=true)]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
    
    }

    public class Oauth2Token
    {
        [Key]
        public int OTokenID { get; set; }
        public string WeiXinOpenID { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Scope { get; set; }
        public virtual User User { get; set; }
    }
}
