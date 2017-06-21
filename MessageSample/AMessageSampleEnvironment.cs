using System;
using AutomaFramework;

namespace MessageSample
{
    class AMessageSampleEnvironment
    {


        static void Main(string[] args)
        {
            new ADynamicEnvironment(typeof(AMessageSender)).Start();
            Console.ReadLine();
        }


    }
}
