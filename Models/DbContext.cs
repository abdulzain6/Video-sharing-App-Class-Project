using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<test.Models.File> Files { get; set; }
        public DbSet<Contact> Contacts { get; set; }

    }
}