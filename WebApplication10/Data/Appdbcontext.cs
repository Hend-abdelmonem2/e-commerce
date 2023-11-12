using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Data
{
    public class Appdbcontext:DbContext

    {
        public   Appdbcontext()
        {
        }

    public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options) { }// object
        public DbSet<RegisterViewModel> Accounts { get; set; }
        public DbSet<user> user { get; set; } 

    }
}
