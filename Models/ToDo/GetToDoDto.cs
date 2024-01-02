using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Models.ToDo
{
    public class GetToDoDto
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}