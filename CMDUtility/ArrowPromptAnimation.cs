using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMDUtility
{
    class ArrowPromptAnimation : PromptAnimation
    {

        public ArrowPromptAnimation(TextWriter writer) : base(writer) { }

        public async override void Start()
        {
            isRunning = true;
            await Task.Run(() =>
            {
                while (isRunning)
                {
                    textWriter.Write('[');
                    int equalsCount = (int)Math.Ceiling(completeness * 15);
                    for (int i = 0; i < equalsCount; i++)
                    {
                        if(i == equalsCount-1 && i != 14)
                        {
                            textWriter.Write('>');
                        }
                        else
                        {
                            textWriter.Write('=');
                        }
                    }
                    for (int i = 0; i < 15 - equalsCount; i++)
                    {
                        textWriter.Write(' ');
                    }
                    textWriter.Write(']');

                    for(int i = 0; i < 17; i++)
                    {
                        textWriter.Write('\b');
                    }

                    Thread.Sleep(150);
                }
            });
        }

        public override void Stop()
        {
            isRunning = false;
        }
    }
}
