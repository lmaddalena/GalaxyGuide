using System;
using System.Linq;
using System.Collections.Generic;
using GalaxyGuide.FiniteStateMachine;
using GalaxyGuide.Mediator;

namespace GalaxyGuide.App
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintBanner();

            IGalaxyEngine engine = new GalaxyEngine();
            string s = "";
            
            s = engine.Evaluate("glob means I");
            if(s != "OK")
                System.Console.WriteLine(s);

            s = engine.Evaluate("prok means V");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("pish means X");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("tegj means L");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("glob glob units of Silver are worth 34 Credits");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("glob prok units of Gold are worth 57800 Credits");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("pish pish units of Iron are worth 3910 Credits");            
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("how much is pish tegj glob glob ?");
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("how many Credits is glob prok Silver ?");            
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("how many Credits is glob prok Gold ?");                        
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("how many Credits is glob prok Iron ?");            
            if(s != "OK")
                System.Console.WriteLine(s);


            s = engine.Evaluate("how much wood could ...");            
            if(s != "OK")
                System.Console.WriteLine(s);

            System.Console.Write("Galaxy Market>");
            Console.ReadLine();
        }

        static void PrintBanner()
        {
            // https://devops.datenkollektiv.de/banner.txt/index.html

            System.Console.WriteLine("\n");
            
            Console.WriteLine(@"   ___         _                     ");
            Console.WriteLine(@"  / _ \  __ _ | |  __ _ __  __ _   _ ");
            Console.WriteLine(@" / /_\/ / _` || | / _` |\ \/ /| | | |");
            Console.WriteLine(@"/ /_\\ | (_| || || (_| | >  < | |_| |");
            Console.WriteLine(@"\____/  \__,_||_| \__,_|/_/\_\ \__, |");
            Console.WriteLine(@"                               |___/ ");
            Console.WriteLine(@"                      _           _   ");
            Console.WriteLine(@"  /\/\    __ _  _ __ | | __  ___ | |_ ");
            Console.WriteLine(@" /    \  / _` || '__|| |/ / / _ \| __|");
            Console.WriteLine(@"/ /\/\ \| (_| || |   |   < |  __/| |_ ");
            Console.WriteLine(@"\/    \/ \__,_||_|   |_|\_\ \___| \__|");            

            System.Console.WriteLine("\n");
            
        }
    }
}
