using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstSample
{
    public class DropDatabaseInitializer<T> : IDatabaseInitializer<T> where T : DbContext, new()
    {
        public DropDatabaseInitializer(Action<T> seed = null)
        {
            Seed = seed ?? delegate { };
        }

        public Action<T> Seed { get; set; }

        public void InitializeDatabase(T context)
        {
            if (context.Database.Exists())
            {
                //删除已经存在的数据库
                context.Database.ExecuteSqlCommand("ALTER DATABASE [" + context.Database.Connection.Database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                context.Database.ExecuteSqlCommand("USE master DROP DATABASE [" + context.Database.Connection.Database + "]");
            }

            context.Database.Create();

            Seed(context);
        }
    }

}
