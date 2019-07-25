using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace SingleInstance
{
    class Program
    {
        private static string MutexName = "runmeonce";
        static void Main(string[] args)
        {
            Mutex mutex = null;
            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(MutexName);
                    mutex.Close();
                    Console.WriteLine("Mutex found");
                    break;
                }
                
                catch (WaitHandleCannotBeOpenedException)
                {
                    mutex = CreateMutex();
                }
                Console.ReadKey();
            }
        }

        static Mutex CreateMutex()
        {
            bool owned = true;
            Console.WriteLine("Mutex not found. Creating mutex.");
            return new Mutex(owned, MutexName);
        }
        
    }
}
