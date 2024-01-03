namespace ToDo.API.Models.ToDo
{
    public class GetToDoDto: BaseToDoDto
    {
        public Guid Uid { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}