using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.UseCase;

namespace Toledo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BirthdaysController : ControllerBase
    {
        private readonly IUseCase<GetBirthdaysRequest, IEnumerable<GetBirthdaysResponse>> _get;

        public BirthdaysController(
           IUseCase<GetBirthdaysRequest, IEnumerable<GetBirthdaysResponse>> get)
        {
            _get = get;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBirthdays(int id)
        {
            var birthdays = _get.Execute(new GetBirthdaysRequest() { Month = id });
            return Ok(birthdays);
        }
    }
}
