using System;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace proj4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Parent Thread Ops
            Console.WriteLine("Current thread: main.\n");
            ParentOps();

            // Child Thread Ops
            Thread[] array = new Thread[3];

            // Begin timer
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            for (int i = 0; i < array.Length; i++)
            {
                ParameterizedThreadStart start = new ParameterizedThreadStart(ChildOps);

                array[i] = new Thread(start);

                switch (i)
                {
                    case 0:
                        array[i].Start("A");
                        break;
                    case 1:
                        array[i].Start("B");
                        break;
                    case 2:
                        array[i].Start("C");
                        break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                array[i].Join();
            }

            // End timer - capture total time elapsed
            sw1.Stop();
            Console.WriteLine("Elapsed Time for all threads is {0} ms", sw1.ElapsedMilliseconds);

            // EOF
            Console.WriteLine("\nCurrent thread: back in main.\n");
            Console.Read();
        }

        // ParentOps() 
        private static void ParentOps()
        {
            Random random = new Random();

            string fname = "Data";
            string sfname = ("../../" + fname + ".txt");
            FileStream fs = new FileStream(sfname, FileMode.OpenOrCreate, FileAccess.Write);
            BufferedStream bs = new BufferedStream(fs);
            Console.WriteLine("Reading from [" + sfname + "]");

            fs.Close();

            StreamWriter sw = new StreamWriter("../../" + fname + ".txt");

            for (int i = 0; i < 10000; i++)
            {
                //Console.WriteLine(random.Next(1, 100));
                sw.WriteLine(random.Next(1, 100) + " ");
            }
            sw.Close();
        }

        // ChildOps(object info)
        static void ChildOps(object info)
        {
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            string fname = "Data";
            string nfname = ("../../" + "Thread_" + info + "_" + fname + ".txt");

            Console.WriteLine(" Inside Thread [" + info + "] to create file [" + nfname + "]");

            File.Copy("../../" + fname + ".txt", nfname);

            sw2.Stop();
            Console.WriteLine(" Elapsed Time for Thread [" + info + "] is {0} ms", sw2.ElapsedMilliseconds);

        }
    }
}