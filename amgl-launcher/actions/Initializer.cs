using System;
using System.Threading;
using System.Threading.Tasks;

namespace amgl.actions
{
    class Initializer
    {
        public static async Task Initialize(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(10000, cancellationToken);
            }
            catch (Exception)
            {
                Console.WriteLine("Initialize cancelled");
            }

            Console.WriteLine("Initialize done");
        }
    }
}
