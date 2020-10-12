using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Train.Domain;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        public ExercisesController()
        {
        }

        [HttpGet]
        public ActionResult<List<Exercise>> GetExercises()
        {
            //var result = this.messages.Dispatch();

            return Ok();
        }
    }
}