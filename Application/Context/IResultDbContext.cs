
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Context
{
    public interface IResultDbContext
    {
        public DbSet<StudentEntity> students { get; set; }
        Task<int> SaveRecord();
       
    }
}
