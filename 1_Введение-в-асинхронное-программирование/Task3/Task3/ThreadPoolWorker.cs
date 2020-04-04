using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task3
{
    internal class ThreadPoolWorker<TResult>
    {
        private readonly Func<object, TResult> func;
        private TResult result;

        public ThreadPoolWorker(Func<object, TResult> func)
        {
            this.func = func ?? throw new ArgumentNullException(nameof(func));
            result = default;
        }
        public bool IsCompleted { get; private set; } = false;
        public bool IsSuccess { get; private set; } = false;
        public bool IsFaulted { get; private set; } = false;
        public Exception Exception { get; private set; } = null;
        public TResult Result
        {
            get
            {
                while (IsCompleted == false)
                {
                    Thread.Sleep(150);
                }
                return IsSuccess == true && Exception == null ? result : throw Exception;
            }
        }

        public void Start(object state)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadExecution), state);
        }

        private void ThreadExecution(object state)
        {
            try
            {
                result = func.Invoke(state);
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
