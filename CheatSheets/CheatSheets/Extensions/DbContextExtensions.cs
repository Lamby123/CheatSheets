namespace CheatSheets.Extensions
{
    using System.Linq;
    using Models;
    using DataAccess;
    using Microsoft.EntityFrameworkCore;

    public static class DbContextExtensions
    {
        public static IQueryable<Employee> GetCompleteCurves(this JamesDbContext context)
        {
            return context.Employee
                .Include(e => e.Job);
        }


        public static Job GetCompleteCurveById(this JamesDbContext context, int id)
        {
            return context.Job
                .Include(i => i.Employees)
                .FirstOrDefault(j => j.JobId == id); 
        }
    }
}
