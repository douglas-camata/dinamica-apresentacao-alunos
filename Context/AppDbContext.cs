using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Context
{

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Resposta> Respostas {get; set;}
    }
}