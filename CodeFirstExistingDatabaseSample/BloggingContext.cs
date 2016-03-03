namespace CodeFirstExistingDatabaseSample
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BloggingContext : DbContext
    {
        //public BloggingContext()
        //    : base("name=BloggingContext")
        //{
        //}

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Oauth2Token> Oauth2Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
