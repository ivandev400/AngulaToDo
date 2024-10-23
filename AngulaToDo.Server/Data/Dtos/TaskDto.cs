namespace AngulaToDo.Server.Data.Dtos
{
    public class TaskDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsImportant { get; set; }
        public bool? Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
    }
}
