using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Models.ToDo
{
    public class CreateToDoDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}