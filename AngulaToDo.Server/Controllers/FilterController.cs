using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AngulaToDo.Server.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    [Route("api/filter")]
    public class FilterController : Controller
    {

    }
}
