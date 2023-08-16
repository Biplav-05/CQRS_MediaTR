using Application.Common;
using MediatR;

namespace Application.Student.AddStudent
{
    public class AddStudentCommand : IRequest<ApiResponse<AddStudentCommand>>
    {
        public string? name { get; set; }
        public string? email { get; set; }
        public string? address { get; set; }
    }
}
