using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WebAppHW10.Models;

namespace WebAppHW10
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) :base(options) {}
        public DbSet<ExpressionModel> ExpressionCache { get; set; }
    }
}