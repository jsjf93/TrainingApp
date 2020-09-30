using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Train.Domain;
using Train.Services.Utils;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly Messages messages;

        public ExercisesController(Messages messages)
        {
            this.messages = messages;
        }

        [HttpGet]
        public ActionResult<List<Exercise>> GetExercises()
        {
            //var result = this.messages.Dispatch();

            return Ok();
        }
    }
}