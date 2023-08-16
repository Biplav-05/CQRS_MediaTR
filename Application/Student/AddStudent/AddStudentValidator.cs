using FluentValidation;

namespace Application.Student.AddStudent
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        public AddStudentValidator()
        {
            RuleFor(x => x.name).NotEmpty();
            RuleFor(x => x.email).NotEmpty();

        }
    }
}
