using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMDUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args[0] == "help")
                {
                    Console.WriteLine("Commands:");
                    Console.WriteLine("\tcircle - run circle ainmation");
                    Console.WriteLine("\tcircle - run dots ainmation");
                    Console.WriteLine("\tarrow - run arrow ainmation");
                    Console.WriteLine();
                    Console.WriteLine("Flags:");
                    Console.WriteLine("\t-d - set duration in seconds");

                    return;
                }

                PromptAnimation animation = null;
                switch (args[0])
                {
                    case "circle":
                        animation = new CirclePromptAnimation(Console.Out);
                        break;
                    case "dots":
                        animation = new DotsPromptAnimation(Console.Out);
                        break;
                    case "arrow":
                        animation = new ArrowPromptAnimation(Console.Out);
                        break;
                    default:
                        throw new Exception();
                }

                int duration = 2500;

                if (args.ToList().Count > 2)
                {
                    if(args[1] == "-d")
                    {
                        duration = int.Parse(args[2])* 1000;
                    }
                }

                Console.Write("Something is starsing");
                animation.Start();
                Task task;

                if (args[0] == "arrow")
                {
                    task = new Task(() => { for (float i = 0; i <= 1; i += 1/15f) { Thread.Sleep(duration / 15); animation.Сompleteness = i; } });
                }
                else
                {
                    task = new Task(() => Thread.Sleep(duration));
                }
                task.Start();

                task.Wait();
                animation.Stop();
                Console.WriteLine("");
                Console.WriteLine("Finished successfully!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Command not found!");
                Console.WriteLine("Write 'cmdutility help' to get help.");
                return;
            }
        }
    }
}
