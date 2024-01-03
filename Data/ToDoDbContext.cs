using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using User.API.Data;

namespace ToDo.API.Data
{
    public class ToDoDbContext: IdentityDbContext<ApiUser>
    {
        public ToDoDbContext(DbContextOptions options): base(options) {
            
        }

        public DbSet<ToDo> ToDo { get; set; }
    }
}