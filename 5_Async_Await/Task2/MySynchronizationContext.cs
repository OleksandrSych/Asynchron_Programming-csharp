using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task2
{
    internal class MySynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Thread thread = new Thread(_ => d.Invoke(state))
            {
                Name = "PostThread",
                IsBackground = true
            };
            thread.Start();
        }
    }
}
