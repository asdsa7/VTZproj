using VTZ.Domain.Entities;
using System.Data.Entity;

namespace VTZ.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
}
