using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EggsDrop.Pokedex.Web.Controllers
{
    /// <summary>
    /// Pokemon API Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        /// <summary>
        /// Retrieve a list of Pokemon
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public ContentResult Get()
        {
            return new ContentResult
            {
                Content = "Success",
                ContentType = "text/html",
                StatusCode = StatusCodes.Status200OK
            };
        }
    }
}