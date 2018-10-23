namespace LetsShop
{
    using LetsShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LetshopContext : DbContext
    {
        public LetshopContext()
            : base("name=LetshopDB")
        {
        }

        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<CategoryDetails> CategoryDetails { get; set; }
        public DbSet<ToastMessages> ToastMessages { get; set; }
        public DbSet<ProductList> ProductList { get; set; }
    }

}