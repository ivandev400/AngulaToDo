using Newtonsoft.Json;

namespace AngulaToDo.Server.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserId { get; set; }

        public User? User { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
