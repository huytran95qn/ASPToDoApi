using Base.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace ToDo.API.Repository
{
    public interface IToDoRepository: IBaseRepository<Data.ToDo>
    {
        
    }
    public class ToDoRepository : IToDoRepository
    {
        private readonly DbContext context;
        private readonly DbSet<Data.ToDo> dbSet;

        public ToDoRepository(DbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<Data.ToDo>();
        }

        public async Task<List<Data.ToDo>> GetAll()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<Data.ToDo> GetById(Guid? uid)
        {
            if (uid is null)
            {
                return null;
            }

            return await dbSet.FindAsync(uid);
        }

        public async Task Add(Data.ToDo entity)
        {
            dbSet.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(Data.ToDo entity)
        {
            dbSet.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task Delete(Guid uid)
        {
            var item = await GetById(uid) ?? throw new InvalidOperationException("No Found");
            dbSet.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}