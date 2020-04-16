using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task4
{
    internal class MySynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            try
            {
                d.Invoke(state);
            }
            catch (Exception e)
            { 
                Console.WriteLine(e.Message);     
            }

        }
    }
}
