using Application.Common;
using Application.Context;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Student.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, ApiResponse<AddStudentCommand>>
    {
        private readonly IResultDbContext _dbContext;
        private readonly IMapper _mapper;
        public AddStudentCommandHandler(IResultDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ApiResponse<AddStudentCommand>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var data = _mapper.Map<StudentEntity>(request);
           await _dbContext.students.AddRangeAsync(data);
            var response = await _dbContext.SaveRecord();
            if(response !=0)
            {
                return ApiResponse<AddStudentCommand>.AsSuccess(request);
            }
            return ApiResponse<AddStudentCommand>.AsError("Data not inserted");
        }
    }
}
