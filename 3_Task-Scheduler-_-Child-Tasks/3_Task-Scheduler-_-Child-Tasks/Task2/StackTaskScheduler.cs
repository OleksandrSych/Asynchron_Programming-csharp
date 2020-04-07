using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    class StackTaskScheduler : TaskScheduler
    {
        Stack<Task> tasksStack = new Stack<Task>(); 
        protected override IEnumerable<Task> GetScheduledTasks()
        {
            lock(tasksStack)
            {
               yield return tasksStack.Peek();
            }
        }

        protected override void QueueTask(Task task)
        {
            tasksStack.Push(task);
        }

        protected override bool TryExecuteTaskInline(Task task, bool taskWasPreviouslyQueued)
        {
            new Thread(() => TryExecuteTask(task)) { IsBackground = true }.Start();
            return false;
        }
    }
}
