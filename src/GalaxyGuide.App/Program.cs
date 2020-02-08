using System;
using System.Linq;
using System.Collections.Generic;
using GalaxyGuide.FiniteStateMachine;
using GalaxyGuide.Mediator;
using GalaxyGuide.RomanNumeralsConverter;
using System.Globalization;

namespace GalaxyGuide.App
{
    class Program
    {
        static string PROMPT = "Merchant's Guide> ";
        static void Main(string[] args)
        {
            if(!System.Console.IsOutputRedirected)
                System.Console.Clear();

            WriteBanner();

            System.Console.WriteLine("\nType exit or quit to terminate");
            System.Console.WriteLine("Type demo to run a demo\n");
            string[] exitCommands = new string[] {"quit", "exit"};

            IGalaxyEngine engine = new GalaxyEngine();
            string sentence = "";
            string response = "";

            while(true)
            {
                try
                {
                    System.Console.Write(PROMPT);
                    sentence = Console.ReadLine();

                    if (exitCommands.Contains(sentence))
                    {
                        WriteResponseMessage("bye");
                        break;
                    }
                    else if(sentence == "demo")
                    {
                        Demo();
                    }
                    else if(sentence != "")
                    {
                        response = engine.Evaluate(sentence);
                        WriteResponseMessage(response);
                    }
                }
                catch (System.Exception ex)
                {
                    WriteException(ex);
                }

            }

            return;
        }

        static void WriteResponseMessage(string response)
        {
            if(response == "OK")
                return;

            var color = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;

            if(response.Contains("Syntax Error"))
            {
                int i = response.IndexOf("Syntax Error");
                System.Console.WriteLine();
                System.Console.Write(response.Substring(0, i));

                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine(response.Substring(i));
                System.Console.WriteLine();
            }
            else
            {
                System.Console.WriteLine("\n" + response + "\n");
            }


            Console.ForegroundColor = color;            
        }

        static void WriteBanner()
        {
            // https://devops.datenkollektiv.de/banner.txt/index.html

            System.Console.WriteLine("\n");

            Console.WriteLine(@"                           _                    _    _          ___         _      _       ");
            Console.WriteLine(@"  /\/\    ___  _ __   ___ | |__    __ _  _ __  | |_ ( ) ___    / _ \ _   _ (_)  __| |  ___ ");
            Console.WriteLine(@" /    \  / _ \| '__| / __|| '_ \  / _` || '_ \ | __||/ / __|  / /_\/| | | || | / _` | / _ \");
            Console.WriteLine(@"/ /\/\ \|  __/| |   | (__ | | | || (_| || | | || |_    \__ \ / /_\\ | |_| || || (_| ||  __/");
            Console.WriteLine(@"\/    \/ \___||_|    \___||_| |_| \__,_||_| |_| \__|   |___/ \____/  \__,_||_| \__,_| \___|");
            Console.WriteLine(@" _            _    _               ___         _                                           ");
            Console.WriteLine(@"| |_   ___   | |_ | |__    ___    / _ \  __ _ | |  __ _ __  __ _   _                       ");
            Console.WriteLine(@"| __| / _ \  | __|| '_ \  / _ \  / /_\/ / _` || | / _` |\ \/ /| | | |                      ");
            Console.WriteLine(@"| |_ | (_) | | |_ | | | ||  __/ / /_\\ | (_| || || (_| | >  < | |_| |                      ");
            Console.WriteLine(@" \__| \___/   \__||_| |_| \___| \____/  \__,_||_| \__,_|/_/\_\ \__, |                      ");
            Console.WriteLine(@"                                                               |___/ "                      );

            System.Console.WriteLine("\n");
            
        }

        private static void WriteException(System.Exception ex)
        {
            string title = "*** Error converting from Roman Numerals";
            string romanNumeral = "";

            if(ex.GetType() == typeof(SymbolsRepetitionException))
            {
                title += "\nSymbol Repetion Error:";
                romanNumeral = ((SymbolsRepetitionException)ex).RomanNumeral;

            }
            else if(ex.GetType() == typeof(InvalidSubtractionException))
            {
                title += "\nInvalid Symbol Subtraction:";
                romanNumeral = ((InvalidSubtractionException)ex).RomanNumeral;

            }
            else if(ex.GetType() == typeof(SymbolValidationException))
            {
                title += "\nSymbol Validation Error:";
                romanNumeral = ((SymbolValidationException)ex).RomanNumeral;

            }
            else 
            {
                title = "*** Unexpected Error";
            }

            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine();
            System.Console.WriteLine(title);                
            System.Console.WriteLine(ex.Message);
            System.Console.WriteLine("Roman Numeral: " + romanNumeral);
            System.Console.WriteLine();
            Console.ForegroundColor = color;

        }

        private static void Demo()
        {
            IGalaxyEngine engine = new GalaxyEngine();

            string response = "";
            string sentence = "";

            sentence = "glob means I";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "prok means V";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "pish means X";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "tegj means L";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "glob glob units of Silver are worth 34 Credits";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "glob prok units of Gold are worth 57800 Credits";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "pish pish units of Iron are worth 3910 Credits";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "how much is pish tegj glob glob ?";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "how many Credits is glob prok Silver ?";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "how many Credits is glob prok Gold ?";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "how many Credits is glob prok Iron ?";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

            sentence = "how much wood could a woodchuck chuck if a woodchuck could chuck wood ?";
            System.Console.WriteLine(PROMPT + sentence);
            response = engine.Evaluate(sentence);
            WriteResponseMessage(response);

        }
    }
}
