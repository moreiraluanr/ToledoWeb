using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Toledo.Aplication.Model;
using Toledo.Aplication.Model.Dependent.Request;
using Toledo.Aplication.Model.Dependent.Response;
using Toledo.Aplication.UseCase;

namespace Toledo.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DependentController : ControllerBase
    {
        private readonly IUseCase<InsertDependetRequest> _insert;
        private readonly IUseCase<AlterDependetRequest> _update;
        private readonly IUseCase<GetDependentRequest, GetDependentResponse> _get;
        private readonly IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>> _list;
        private readonly IUseCase<RemoveDependetRequest> _remove;

        public DependentController(
            IUseCase<InsertDependetRequest> insert,
            IUseCase<AlterDependetRequest> update,
            IUseCase<GetDependentRequest, GetDependentResponse> get,
            IUseCase<ListDependentRequest, IEnumerable<ListDependentResponse>> list,
            IUseCase<RemoveDependetRequest> remove)
        {
            _insert = insert;
            _update = update;
            _get = get;
            _list = list;
            _remove = remove;
        }

        [HttpPost]
        public IActionResult Insert([FromBody] InsertDependetRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _insert.Execute(request);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] AlterDependetRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _update.Execute(request);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_get.Execute(new GetDependentRequest() { Id = id }));
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_list.Execute(new ListDependentRequest()));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _remove.Execute(new RemoveDependetRequest() { Id = id });
            return NoContent();
        }
    }
}
