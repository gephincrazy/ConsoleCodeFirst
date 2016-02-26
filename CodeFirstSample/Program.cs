using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeFirstSample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProductContext())
            {
                //删除已经存在的数据库
                //DropDatabaseInitializer<ProductContext> dbi = new DropDatabaseInitializer<ProductContext>();
                //dbi.InitializeDatabase(db);

                // Create and save a new Blog 
                Console.Write("Enter a name for a new product: ");
                var name = Console.ReadLine();

                var product = new Product { Name = name };
                db.Products.Add(product);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Products
                            orderby b.Name
                            select b;

                Console.WriteLine("All products in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }

    public class Product
    {
        public int Key { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        //public string description { get; set; }
        public ProductCategory Category { get; set; }
    }

    public class ProductCategory
    {
        public int Key { get; set; }
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }

    public class ProductContext : DbContext
    {
        static ProductContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductContext>());
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //设置key作为主键
            modelBuilder.Properties()
                        .Where(p => p.Name == "Key")
                        .Configure(p => p.IsKey());


            //设置复合主键
            //modelBuilder.Properties<int>()
            //    .Where(x => x.Name == "Key")
            //    .Configure(x => x.IsKey().HasColumnOrder(1));

            //modelBuilder.Properties()
            //            .Where(x => x.Name == "Name")
            //            .Configure(x => x.IsKey().HasColumnOrder(2));
        }


    }

}
