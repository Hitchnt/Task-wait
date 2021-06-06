using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace async_Example
{
    class Program
    {
        IList<Cat> cats;
        IList<Food> food;

        static string Word1 = "";
        static string Word2 = "";

        static void Main(string[] args)
        {
            Dothhis();

        }

        public static void Dothhis()
        {

            //string Word1 = await RunTwoThingsAsync();
            //string Word2 = await RunTwoThingsAsync();


            bool more = false;


            more = ExecuteWithTimeLimit(TimeSpan.FromMilliseconds(8000), () =>
            {
                //RunTwoThingsAsync();

                //Word1 = await Task.Run(() => GetWord2());
                //Word2 = await Task.Run(() => GetWord1());

                //GetWord1();
                //GetWord2();


            });

            if (more)
            {
             Console.WriteLine(Word1 + "  -  " + Word2);
            }
            else
            {
                Console.WriteLine(" Found nothing");
            }
            

        }
        public static async void RunTwoThingsAsync()
        {

            var catTask = Task.Run(() => GetWord2());
            var fTask = Task.Run(() => GetWord1());

            //var cats = await cTask;
            //var food = await fTask;

            //var cats="";
            //var food="";
           

            var cats = await catTask;
            var food = await fTask;

            //cats = await Task.Run(() =>
            //{

            //    return GetWord2();
            //});


            //food = await Task.Run(() =>
            //{
            //    return GetWord2();
            //});

            //string value = "";
            //if (cats.ToString() != "" )
            //{
            //    Word1 = cats.ToString();
            //}
            //else if (food.ToString() != "")
            //{
            //    Word2 = food.ToString();
            //}
            //else
            //{
            //    value = "get nothing";
            //}
           

            //return ;
           
        }


        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
        
                try
                {
                Task get1 = Task.Factory.StartNew(() => GetWord1());
                Task get2 = Task.Factory.StartNew(() => GetWord2());
                get1.Wait(timeSpan);
                if (get1.IsCompleted || get2.IsCompleted)
                {
                    return true;
                }
               

                }
                catch (AggregateException ae)
                {
                    throw ae.InnerExceptions[0];
                }
          

            

            return false;
        }

        private static string GetWord1()
        {

            var timer = new Stopwatch();
            timer.Start();
            while (timer.ElapsedMilliseconds  <= 15000 )
            {

            }
            timer.Stop();
            Word1 = " this word 1 ";

            return "this word 1 ";
           // return "";
        }

        private static string GetWord2()
        {
            var timer = new Stopwatch();
            timer.Start();
            while (timer.ElapsedMilliseconds <= 3000)
            {

            }
            Word2 = "this word 2 ";

            return "this word 2 ";
            //return "";
        }

    }
}
