using Microsoft.AspNetCore.Identity;

namespace AngulaToDo.Server.Models
{
    public class User : IdentityUser
    {
        public List<Task> Tasks { get; set; }
    }
}
