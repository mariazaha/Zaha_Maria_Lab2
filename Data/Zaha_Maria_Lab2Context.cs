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
        public Zaha_Maria_Lab2Context (DbContextOptions<Zaha_Maria_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Zaha_Maria_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Zaha_Maria_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Zaha_Maria_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
