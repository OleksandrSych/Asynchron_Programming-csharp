using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    internal class ThreadPoolWorker
    {
        private readonly Action<object> action;
        public ThreadPoolWorker(Action<object> action)
        {
            this.action = action ?? throw new ArgumentNullException(nameof(action));
        }
        public bool IsCompleted { get; private set; } = false;
        public bool IsSuccess { get; private set; } = false;
        public bool IsFaulted { get; private set; } = false;
        public Exception Exception { get; private set; } = null;
        public void Start(object obj)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), obj);
            
        }
        public void Wait()
        {
            while(!IsCompleted)
            {
                Thread.Sleep(100);
            }
            if (Exception != null)
            {
                throw Exception;
            }
        }
        private void ThreadExecution(object obj)
        {
            try
            {
                action.Invoke(obj);
                IsSuccess = true;
                IsFaulted = false;
            }
            catch (Exception ex)
            {
                Exception = ex;
                IsSuccess = false;
                IsFaulted = true;
            }
            finally
            {
                IsCompleted = true;
            }
        }

    }
}
