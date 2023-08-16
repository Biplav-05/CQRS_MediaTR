using MediatR;

namespace Application.Student.GetAllStudent
{
    public class GetAllStudentRequest : IRequest<List<GetAllStudentResponse>>
    {
    }
}
