using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Common.Controllers
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public abstract class ApiController: ControllerBase
    {

    }
}
