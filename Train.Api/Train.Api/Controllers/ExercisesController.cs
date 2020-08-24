using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Train.Domain;
using Train.Services.QueryProcessors.Interfaces;

namespace Train.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IGetExercisesQueryProcessor queryProcessor;

        public ExercisesController(IGetExercisesQueryProcessor queryProcessor)
        {
            this.queryProcessor = queryProcessor;
        }

        [HttpGet]
        public ActionResult<List<Exercise>> GetExercises()
        {
            var result = queryProcessor.Process();

            return result;
        }
    }
}