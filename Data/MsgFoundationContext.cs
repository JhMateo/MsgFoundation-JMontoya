using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MsgFoundation.Models;

namespace MsgFoundation.Data
{
    public class MsgFoundationContext : DbContext
    {
        public MsgFoundationContext(DbContextOptions<MsgFoundationContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Observation> Observations => Set<Observation>();
        public DbSet<Credit> Credits => Set<Credit>();
        public DbSet<Motociclista> Motociclistas => Set<Motociclista>();
        public DbSet<Tecnomecanica> Tecnomecanicas => Set<Tecnomecanica>();
    }   
}
