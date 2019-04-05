namespace CheatSheets.Threading
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using DataAccess;
    public class ThreadingExample
    {

        public readonly JamesDbContext Context;
        public object _lock = new Object();


        public ThreadingExample(JamesDbContext context)
        {
            this.Context = context;
        }


        public void KickOffThreadsAndWait(int numberOfThreads)
        {
            var list = new List<Employee>();
            while (list.Count() > 0)
            {
                var threads = new List<Thread>();
                foreach (var employee in list.Take(100))
                {
                    var thread = new Thread(() => Process(employee));
                    thread.Start();
                    threads.Add(thread);
                }
                threads.ForEach(t => t.Join());
            }
        }


        public void Process(Employee input)
        {
            // do some processing of the input object in here. 
            SaveWithoutDeadlock(input);
        }


        public void SaveWithoutDeadlock(Employee input)
        {

            lock (_lock)
            {
                // do something in here that might deadlock... e.g. saving to the database using singleton dbcontext
                Context.Employee.Add(input);
                Context.SaveChanges();
            }
        }
    }
}
