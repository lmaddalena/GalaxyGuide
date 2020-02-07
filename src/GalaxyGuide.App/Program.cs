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

        }
    }
}
