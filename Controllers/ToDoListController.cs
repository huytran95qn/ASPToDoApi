using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Models.ToDo;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly Data.ToDoDbContext context;
        private readonly IMapper mapper;

        public ToDoController(Data.ToDoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        // Get: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetToDoDto>>> GetToDoList()
        {
            var list = await context.ToDo.ToListAsync();
            return Ok(mapper.Map<List<GetToDoDto>>(list));
        }

        // Get: api/ToDo/{uid}
        [HttpGet("{uid}")]
        public async Task<ActionResult<GetToDoDto>> GetToDoById(Guid uid)
        {
            var toDoItem = await context.ToDo.FindAsync(uid);
            if(toDoItem == null) {
                return NotFound();
            }

            return mapper.Map<GetToDoDto>(toDoItem);
        }

        //Post: api/ToDo
        [HttpPost]
        public async Task<IActionResult> PostToDo(CreateToDoDto createData) {
            var data = mapper.Map<Data.ToDo>(createData);
            data.Uid = Guid.NewGuid();
            data.StartDate = DateTime.UtcNow.ToString();

            context.ToDo.Add(data);
            await context.SaveChangesAsync();

            return NoContent();
        }

        //Put: api/ToDo/{uid}
        [HttpPut("{uid}")]
        public async Task<IActionResult> UpdateDescription(string uid, UpdateToDoDto updateData) {
            var toDoItem = await context.ToDo.FindAsync(uid);
            if(toDoItem == null) {
                return NotFound();
            }
            
            try
            {
                toDoItem.Name = updateData.Name;
                toDoItem.Description = updateData.Description;
                context.Entry(toDoItem).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/ToDo/{uid}
        [HttpDelete("{uid}")]
        public async Task<IActionResult> DeleteToDo(Guid uid)
        {
            var toDoItem = await context.ToDo.FindAsync(uid);
            if(toDoItem == null) {
                return NotFound();
            }

            context.ToDo.Remove(toDoItem);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}