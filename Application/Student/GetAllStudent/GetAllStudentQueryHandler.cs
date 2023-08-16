using Application.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Student.GetAllStudent
{
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentRequest, List<GetAllStudentResponse>>
    {
        private readonly IResultDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetAllStudentQueryHandler(IResultDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<GetAllStudentResponse>> Handle(GetAllStudentRequest request, CancellationToken cancellationToken)
        {
            return await _dbContext.students.ProjectTo<GetAllStudentResponse>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
