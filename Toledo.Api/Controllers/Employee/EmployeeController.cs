using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.UseCase;

namespace Toledo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IUseCase<InsertEmployeeRequest> _insertUseCase;
        private readonly IUseCase<AlterEmployeeRequest> _alterUseCase;
        private readonly IUseCase<GetEmployeeRequest, GetEmployeeResponse> _getUseCase;
        private readonly IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>> _listUseCase;
        private readonly IUseCase<RemoveEmployeeRequest> _removeUseCase;

        public EmployeeController(
            IUseCase<InsertEmployeeRequest> insertUseCase,
            IUseCase<AlterEmployeeRequest> alterUseCase,
            IUseCase<GetEmployeeRequest, GetEmployeeResponse> getUseCase,
            IUseCase<ListEmployeeRequest, IEnumerable<ListEmployeeResponse>> listUseCase,
            IUseCase<RemoveEmployeeRequest> removeUseCase)
        {
            _insertUseCase = insertUseCase;
            _alterUseCase = alterUseCase;
            _getUseCase = getUseCase;
            _listUseCase = listUseCase;
            _removeUseCase = removeUseCase;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] InsertEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _insertUseCase.Execute(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] AlterEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _alterUseCase.Execute(request);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            return Ok(_getUseCase.Execute(new GetEmployeeRequest() {Id = id }));
        }

        [HttpGet]
        public IActionResult List([FromBody] ListEmployeeRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(_listUseCase.Execute(request));
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            _removeUseCase.Execute(new RemoveEmployeeRequest() { Id = id });
            return NoContent();
        }
    }
}
