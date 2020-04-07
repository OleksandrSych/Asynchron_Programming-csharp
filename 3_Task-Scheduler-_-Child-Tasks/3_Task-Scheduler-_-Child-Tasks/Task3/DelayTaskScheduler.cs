using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    class DelayTaskScheduler : TaskScheduler
    {
        Task task;
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            return Enumerable.Empty<Task>();
        }

        protected override void QueueTask(Task task)
        { 
            ThreadPool.RegisterWaitForSingleObject(
                new AutoResetEvent(false),
                new WaitOrTimerCallback((st, to) => TryExecuteTask((Task)st)),
                task,
                2000,
                true
            );

        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            return false;
        }
    }
}
