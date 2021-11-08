using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ProCodeGuide.Sample.Async
{
    public class Program
    {
        static readonly Stopwatch timer = new Stopwatch();
        public static async Task Main(string[] args)
        {
            timer.Start();
            Console.WriteLine("Program Start - " + timer.Elapsed.ToString());

            Task task1Task = Task1Async();
            Task task2Task = Task2Async();

            try
            {
                await Task.WhenAll(task1Task, task2Task);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

            Console.WriteLine("Program End - " + timer.Elapsed.ToString());
            timer.Stop();
        }

        private static async Task Task1Async()
        {
            Console.WriteLine("Async Task 1 Started - " + timer.Elapsed.TotalSeconds.ToString());
            await Task.Delay(2000);
            throw new Exception("Async Task 1 Failed");
            //Console.WriteLine("Async Task 1 Completed - " + timer.Elapsed.TotalSeconds.ToString());
        }

        private static async Task Task2Async()
        {
            Console.WriteLine("Async Task 2 Started - " + timer.Elapsed.TotalSeconds.ToString());
            await Task.Delay(3000);
            Console.WriteLine("Async Task 2 Completed - " + timer.Elapsed.TotalSeconds.ToString());
        }

        private static void Task1()
        {
            Console.WriteLine("Task 1 Started - " + timer.Elapsed.TotalSeconds.ToString());
            Thread.Sleep(2000);
            Console.WriteLine("Task 1 Completed - " + timer.Elapsed.TotalSeconds.ToString());
        }

        private static void Task2()
        {
            Console.WriteLine("Task 2 Started - " + timer.Elapsed.TotalSeconds.ToString());
            Thread.Sleep(3000);
            Console.WriteLine("Task 2 Completed - " + timer.Elapsed.TotalSeconds.ToString());
        }
    }
}