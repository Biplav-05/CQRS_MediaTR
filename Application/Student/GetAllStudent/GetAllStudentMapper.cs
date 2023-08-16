using AutoMapper;
using Domain.Entities;

namespace Application.Student.GetAllStudent
{
    public class GetAllStudentMapper : Profile
    {
        public GetAllStudentMapper()
        {
            CreateMap<StudentEntity, GetAllStudentResponse>();
        }
    }
}
