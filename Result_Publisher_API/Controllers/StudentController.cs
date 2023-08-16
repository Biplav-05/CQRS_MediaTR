
using Application.Common;
using Application.Student.AddStudent;
using Application.Student.GetAllStudent;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Result_Publisher_API.Controllers
{
    [ApiController]
    [Route("api/")]
    public class StudentController : Controller
    {
        private readonly BaseController _baseController;
        private IMediator _mediator;
        public StudentController(IMediator mediator, BaseController baseController)
        {
            _mediator = mediator;
            _baseController = baseController;
        }

        [HttpGet]
        [Route("student")]
        public async Task<IActionResult> GetAllStudent ()
        {
            var data = new GetAllStudentRequest();
            var response = await _mediator.Send(data);
            return Ok(response);
        }
        [HttpPost]
        [Route("student")]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception ex)
            {
               return _baseController.GetApiResponse<ApiResponse<AddStudentCommand>>(ex);
            }
        }


    }
}
