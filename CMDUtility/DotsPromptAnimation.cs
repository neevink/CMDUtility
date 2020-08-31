using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMDUtility
{
    class DotsPromptAnimation : PromptAnimation
    {
        public DotsPromptAnimation(TextWriter writer) : base(writer) { }

        public async override void Start()
        {
            isRunning = true;
            await Task.Run(() =>
            {
                while (isRunning)
                {
                    foreach (var e in new string[] { "", ".", "..", "...",})
                    {
                        if (isRunning)
                        {
                            textWriter.Write(e);
                            Thread.Sleep(150);
                            for (int i = 0; i < e.Length; i++)
                            {
                                Console.Write("\b");
                            }
                            for (int i = 0; i < e.Length; i++)
                            {
                                Console.Write(" ");
                            }
                            for (int i = 0; i < e.Length; i++)
                            {
                                Console.Write("\b");
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            });
        }

        public override void Stop()
        {
            isRunning = false;
        }
    }
}
