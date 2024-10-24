namespace AngulaToDo.Server.Data.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool? IsImportant { get; set; }
        public bool? Completed { get; set; }
        public DateTime Created { get; set; }
        public DateTime DueDate { get; set; }
        public int? CategoryId { get; set; }
    }
}
