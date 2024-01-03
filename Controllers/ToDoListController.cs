using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.API.Data;
using ToDo.API.Models.ToDo;
using ToDo.API.Repository;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController: ControllerBase
    {
        private readonly IToDoRepository toDoRepository;
        private readonly IMapper mapper;

        public ToDoController(ToDoDbContext context, IMapper mapper)
        {
            toDoRepository = new ToDoRepository(context);
            this.mapper = mapper;
        }

        // Get: api/ToDo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetToDoDto>>> GetToDoList()
        {
            var list = await toDoRepository.GetAll();
            return Ok(mapper.Map<List<GetToDoDto>>(list));
        }

        // Get: api/ToDo/{uid}
        [HttpGet("{uid}")]
        public async Task<ActionResult<GetToDoDto>> GetToDoById(Guid uid)
        {
            var toDoItem = await toDoRepository.GetById(uid);
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

            await toDoRepository.Add(data);
            return NoContent();
        }

        //Put: api/ToDo/{uid}
        [HttpPut("{uid}")]
        public async Task<IActionResult> PutToDo(Guid uid, UpdateToDoDto updateData) {
            var item = await toDoRepository.GetById(uid);
            if(item is null)
            {
                return NotFound();
            }
            
            try
            {
                mapper.Map(updateData, item);
                await toDoRepository.Update(item);
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
            try
            {
                await toDoRepository.Delete(uid);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}