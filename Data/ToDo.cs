using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Data
{
    public class ToDo
    {
        [Key]
        public Guid Uid { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}