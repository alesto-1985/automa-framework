using System;
using AutomaFramework;

namespace PreconditionsSample
{
    public class AMainEnvironment : AEnvironment
    {


        protected override void InitElements()
        {
            AddAutoma(new AExecutor());
            AddAutoma(new AExecutor2());
            AddAutoma(new AExecutor3());
            AddAutoma(new AListener());
        }



        protected override void StartElements()
        {            
            StartAutoma("AExecutor");
            StartAutoma("AExecutor2");
        }



        public static void Main()
        {
            try
            {
                new AMainEnvironment().Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + " - " + e.StackTrace);
            }
            Console.ReadLine();
        }


    }
}
