using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Models.ToDo
{

    public class UpdateToDoDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}