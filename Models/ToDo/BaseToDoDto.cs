using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Models.ToDo
{
    public class BaseToDoDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}