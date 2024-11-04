using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zaha_Maria_Lab2.Models;

namespace Zaha_Maria_Lab2.Data
{
    public class Zaha_Maria_Lab2Context : DbContext
    {
        public Zaha_Maria_Lab2Context(DbContextOptions<Zaha_Maria_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Borrowing> Borrowing { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Borrowing)
                .WithOne(br => br.Book)
                .HasForeignKey<Borrowing>(br => br.BookID); 
        }
        public DbSet<Zaha_Maria_Lab2.Models.Member> Member { get; set; } = default!;
    }
}