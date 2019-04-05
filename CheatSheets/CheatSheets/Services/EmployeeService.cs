namespace CheatSheets.Services
{
    using Models;
    using DataAccess;
    using System.Collections.Generic;
    using System.Linq;
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees(JamesDbContext ctx);
        Employee GetEmployeeById(JamesDbContext ctx, int id);
        IEnumerable<Employee> GetEmployeeById(JamesDbContext ctx, List<int> ids);
        IEnumerable <Employee> GetEmployeeByJobName(JamesDbContext ctx, string jobName);
    }
    public class EmployeeService : IEmployeeService
    {

        public EmployeeService()
        {}


        public IEnumerable<Employee> GetEmployees(JamesDbContext ctx) =>
             ctx.Employee;


        public Employee GetEmployeeById(JamesDbContext ctx, int id) =>
             ctx.Employee.FirstOrDefault(e => e.EmployeeId == id);

        public IEnumerable<Employee> GetEmployeeById(JamesDbContext ctx, List<int> ids) =>
             ctx.Employee.Where(e => ids.Contains(e.EmployeeId));

        public IEnumerable<Employee> GetEmployeeByJobName(JamesDbContext ctx, string jobName)
        {
            var job = ctx.Job.FirstOrDefault(j => j.JobName == jobName);
            return ctx.Employee.Where(e => e.JobId == job.JobId);
        }


    }
}
