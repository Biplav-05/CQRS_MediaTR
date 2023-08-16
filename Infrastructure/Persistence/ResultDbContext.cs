using Application.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ResultDbContext : DbContext, IResultDbContext
    {
        public ResultDbContext(DbContextOptions options) : base(options){ }

        public DbSet<StudentEntity> students { get ; set ; }

        public async Task<int> SaveRecord()
        {
            return await SaveChangesAsync(); 
        }
    }
}
