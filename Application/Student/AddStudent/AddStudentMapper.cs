using AutoMapper;
using Domain.Entities;

namespace Application.Student.AddStudent
{
    public class AddStudentMapper : Profile
    {
        public AddStudentMapper()
        {
            CreateMap<AddStudentCommand, StudentEntity>();
        }
    }
}
