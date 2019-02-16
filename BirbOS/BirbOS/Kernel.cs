using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace BirbOS
{
    public class Kernel : Sys.Kernel
    {

        private static string user = "";

        protected override void BeforeRun()
        {
            Console.WriteLine("BBBB      B     BBBBBB      BBBB       BBBB      BBBBB");
            Console.WriteLine("B   B           B     B     B   B     B    B    B");
            Console.WriteLine("B    B    B     B     B     B    B    B    B   B");
            Console.WriteLine("BBBBB     B     BBBBBBB     BBBBB     B    B   BBBBBBB");
            Console.WriteLine("B    B    B     BB          B    B    B    B         B");
            Console.WriteLine("B   B     B     B  B        B   B     B    B        B");
            Console.WriteLine("BBBB      B     B   BB      BBBB       BBBB    BBBBB");
        }

        protected override void Run()
        {
            Console.Write(user + "@birbOS ~:");
            var input = Console.ReadLine().ToLower();
            if (input == "help")
            {
                Console.WriteLine("Commands are: help, owo, uwu, birb, calculate, stfu, changelog, about");

            } else if (input == "owo")
            {
                Console.WriteLine("uwu");
            } else if (input == "uwu")
            {
                Console.WriteLine("owo");
            } else if (input == "birb")
            {
                Console.WriteLine("BIIIIIIRB");
            } else if (input == "calculator")
            {
                Console.WriteLine("The calculator is in an early stage. You may experience crashes and bugs. Have fun!");
                Console.WriteLine("Type exit to go to the prompt");
                Console.Write("First number:");
                var fn = Console.ReadLine();
                if (fn == "exit")
                {

                } else
                {
                    Console.Write("Second number:");
                    var sn = Console.ReadLine();
                    if (sn == "exit")
                    {

                    } else
                    {
                        Console.Write("Equation: (+,-,*,/)");
                        var e = Console.ReadLine();
                        if (e == "exit")
                        {

                        } else
                        {
                            int end = 0;
                            if (e == "+")
                            {
                                end = int.Parse(fn) + int.Parse(sn);
                            } else if (e == "-")
                            {
                                end = int.Parse(fn) - int.Parse(sn);
                            } else if (e == "*")
                            {
                                end = int.Parse(fn) * int.Parse(sn);
                            } else if (e == "/")
                            {
                                end = int.Parse(fn) / int.Parse(sn);
                            }
                            Console.WriteLine(end.ToString());
                        }
                    }
                }
            } else if (input == "stfu")
            {
                Console.WriteLine("no u");
            } else if (input == "about")
            {
                Console.WriteLine("birbOS (real OS edition) Build 1.0 based on birbOS Build 8.2 - real OS edition developed by Samyocord, original version developed by xandrei, Dukemz and Ad2017.");
            } else if (input == "changelog")
            {
                Console.WriteLine("Build 1.0");
                Console.WriteLine("Initial release");
            } else
            {
                Console.WriteLine("This command has not been implemented yet.");
            }
        }
    }
}
