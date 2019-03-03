using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;
using Cosmos.Core;
using Cosmos.HAL;

namespace BirbOS
{
    public class Kernel : Sys.Kernel
    {

        private static string user;

        protected override void BeforeRun()
        {
            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            clear();
            Console.WriteLine("BBBB      B     BBBBBB      BBBB       BBBB      BBBBB");
            Console.WriteLine("B   B           B     B     B   B     B    B    B");
            Console.WriteLine("B    B    B     B     B     B    B    B    B   B");
            Console.WriteLine("BBBBB     B     BBBBBBB     BBBBB     B    B   BBBBBBB");
            Console.WriteLine("B    B    B     BB          B    B    B    B         B");
            Console.WriteLine("B   B     B     B  B        B   B     B    B        B");
            Console.WriteLine("BBBB      B     B   BB      BBBB       BBBB    BBBBB");
            Console.WriteLine("");
        }

        private void login()
        {
            Console.WriteLine("Please enter your username:");
            var username = Console.ReadLine();
            if (Directory.Exists("0:\\users\\" + username))
            {
                try
                {
                    Console.WriteLine("Please enter your password:");
                    var password = Console.ReadLine();
                    var pass = File.ReadAllText("0:\\users\\" + username + "\\pw.birbuser");
                    if (pass == password)
                    {
                        user = username;
                        Console.WriteLine("Welcome " + username + "!");
                    }
                } catch (Exception e)
                {
                    crash("ERROR_GET_USERINFO");
                }
            } else
            {
                try
                {
                    Console.WriteLine("This user does not exist");
                    WaitSeconds(1);
                    Sys.Power.Reboot();
                } catch (Exception e)
                {
                    crash("ERROR_SYSTEM_THREADING");
                }
            }
        }

        private void firstRun()
        {
            Console.WriteLine("BirbOS is started for the first time.");
            Console.Write("Please enter your username:");
            var username = Console.ReadLine();
            Console.Write("Please enter your password:");
            var password = Console.ReadLine();
            Console.Write("Please re-enter your password:");
            var repassword = Console.ReadLine();
            if (password == repassword)
            {
                try
                {
                    Directory.CreateDirectory("users");
                    Directory.CreateDirectory("users\\" + username);
                    File.Create("0:\\users\\" + username + "\\pw.birbuser");
                    File.WriteAllText("0:\\users\\" + username + "\\pw.birbuser", password);
                    Console.WriteLine("User created!");
                    user = username;
                    Console.WriteLine("Enjoy BirbOS!");
                    Directory.CreateDirectory("apps");
                } catch (Exception e)
                {
                    crash("ERROR_CREATING_USER");
                }
            }
            else
            {
                try
                {
                    Console.WriteLine("The re-entered password is wrong!");
                    WaitSeconds(1);
                    Sys.Power.Reboot();
                } catch (Exception e)
                {
                    crash("ERROR_SYSTEM_THREADING");
                }
            }
        }

        //Because I'm too stupid to search for a method to clear the console with Cosmos.
        public static void clear()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
        }

        protected override void Run()
        {
            if (!Directory.Exists("0:\\users"))
            {
                firstRun();
            } else
            {
                if (user == null)
                {
                    login();
                }
            }
            Console.Write(user + "@birbOS ~:");
            var input = Console.ReadLine().ToLower();
            if (input == "help")
            {
                Console.WriteLine("Commands are: help, owo, uwu, birb, calculate, stfu, changelog, about, folder, crash, dir, ls");

            }
            else if (input == "owo")
            {
                Console.WriteLine("uwu");
            }
            else if (input == "uwu")
            {
                Console.WriteLine("owo");
            }
            else if (input == "birb")
            {
                Console.WriteLine("BIIIIIIRB");
            }
            else if (input == "calculate")
            {
                Console.WriteLine("The calculator is in an early stage. You may experience crashes and bugs. Have fun!");
                Console.WriteLine("Type exit to go to the prompt");
                Console.Write("First number:");
                var fn = Console.ReadLine();
                if (fn == "exit")
                {

                }
                else
                {
                    Console.Write("Second number:");
                    var sn = Console.ReadLine();
                    if (sn == "exit")
                    {

                    }
                    else
                    {
                        Console.Write("Equation: (+,-,*,/)");
                        var e = Console.ReadLine();
                        if (e == "exit")
                        {

                        }
                        else
                        {
                            double end = 0;
                            if (e == "+")
                            {
                                end = int.Parse(fn) + int.Parse(sn);
                            }
                            else if (e == "-")
                            {
                                end = int.Parse(fn) - int.Parse(sn);
                            }
                            else if (e == "*")
                            {
                                end = int.Parse(fn) * int.Parse(sn);
                            }
                            else if (e == "/")
                            {
                                end = int.Parse(fn) / int.Parse(sn);
                            }
                            Console.WriteLine(end.ToString());
                        }
                    }
                }
            }
            else if (input == "stfu")
            {
                Console.WriteLine("no u");
            }
            else if (input == "about")
            {
                Console.WriteLine("birbOS (real OS edition) Build 1.1 based on birbOS Build 8.2 - real OS edition developed by Samyocord, original version developed by xandrei, Dukemz and Ad2017.");
            }
            else if (input == "changelog")
            {
                Console.WriteLine("Build 1.1");
                Console.WriteLine("Added user system");
                Console.WriteLine("Added BSOD (crash BirbOS with crash <Stop code>)");
                Console.WriteLine("You can now create folders - wow");
                Console.WriteLine("Theme system - by Ad2017");
                Console.WriteLine("--------");
                Console.WriteLine("Build 1.0");
                Console.WriteLine("Initial release");
            }
            else if (input == "theme")
            {
                Console.WriteLine("Themes : default, light, hacker");
                Console.WriteLine("Theme : ");
                var theme = Console.ReadLine();
                if (theme == "default")
                {
                    Console.ResetColor();
                }
                else
                if (theme == "light")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                if (theme == "hacker")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.WriteLine("Unknown theme");
                }
            }
            else if (input.StartsWith("folder"))
            {
                if (!Directory.Exists("0:\\"+ ReplaceFirst(input, "folder ", "").Trim()))
                {
                    Directory.CreateDirectory("0:\\" + ReplaceFirst(input, "folder ", "").Trim());
                    Console.WriteLine("Successfully created the folder");
                }
                else
                {
                    Console.WriteLine("This folder already exists!");
                }
            } else if (input.StartsWith("crash"))
            {
                crash(ReplaceFirst(input, "crash", ""));
            } else if (input == "dir" || input == "ls")
            {
                for (int i = 0; i < GetDirFadr("0://").Length; i++)
                {
                    Console.WriteLine("<DIR>    " + GetDirFadr("0://")[i]);
                }
                for (int i = 0; i < GetFsFadr("0://").Length; i++)
                {
                    Console.WriteLine("         " + GetFsFadr("0://")[i]);
                }
                Console.WriteLine();
                Console.WriteLine("         " + GetFsFadr("0://").Length + " files");
                Console.WriteLine("         " + GetDirFadr("0://").Length + " folders");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("This command has not been implemented yet.");
            }
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        public static void crash(string errorCode)
        {
            clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("BirbOS");
            Console.WriteLine("BirbOS encountered an error.");
            Console.WriteLine("Stop code: " + errorCode);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Join our Discord and ask for help:");
            Console.WriteLine("https://discord.gg/DkCP9G2");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("BirbOS will reboot in 5 seconds...");
            Console.WriteLine("");
            WaitSeconds(5);
            Sys.Power.Reboot();
        }

        //Stolen from the interwebz
        public static void WaitSeconds(int secNum)
        {
            int StartSec = RTC.Second;
            int EndSec;
            if (StartSec + secNum > 59)
            {
                EndSec = 0;
            }
            else
            {
                EndSec = StartSec + secNum;
            }
            while (RTC.Second != EndSec)
            {
                
            }
        }

        public string[] GetFsFadr(string Adr) // Get Files From Address
        {
            string[] Files = new string[256];
            if (Directory.GetFiles(Adr).Length > 0)
                Files = Directory.GetFiles(Adr);
            else
                Files[0] = "No files found.";
            return Files;
        }
        public string[] GetDirFadr(string Adr) // Get Directories From Address
        {
            var Dirs = Directory.GetDirectories(Adr);
            return Dirs;
        }

    }
}
