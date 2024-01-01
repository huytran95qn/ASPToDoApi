using Microsoft.EntityFrameworkCore;

namespace ToDO.API.Data
{
    public class ToDoDbContext: DbContext
    {
        public ToDoDbContext(DbContextOptions options): base(options) {
            
        }
    }
}