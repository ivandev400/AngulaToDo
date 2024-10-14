using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Models
{
    public class User : IdentityUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
