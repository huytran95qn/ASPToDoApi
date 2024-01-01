using Microsoft.EntityFrameworkCore;

namespace ToDo.API.Data
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions options): base(options) {
            
        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}