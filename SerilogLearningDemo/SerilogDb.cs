using Microsoft.EntityFrameworkCore;

namespace SerilogLearningDemo
{
    public class SerilogDb:DbContext
    {
        public SerilogDb(DbContextOptions<SerilogDb> options) :base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
