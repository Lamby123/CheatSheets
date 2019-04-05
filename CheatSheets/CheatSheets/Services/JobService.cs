
namespace CheatSheets.Services
{
    using Models;
    using DataAccess;
    using System.Collections.Generic;
    using System.Linq;

    public interface IJobService
    {

    }
    public class JobService : IJobService
    {
        public JobService() { }

        public IEnumerable<Job> GetJobs(JamesDbContext ctx) =>
           ctx.Job;


        public Job GetJobById(JamesDbContext ctx, int id) =>
             ctx.Job.FirstOrDefault(e => e.JobId == id);
    }
}
