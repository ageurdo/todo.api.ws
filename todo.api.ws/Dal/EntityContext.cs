using Microsoft.EntityFrameworkCore;
using todo.api.ws.Models;

namespace todo.api.ws.Dal
{
    public class EntityContext : DbContext
    {

        public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}
