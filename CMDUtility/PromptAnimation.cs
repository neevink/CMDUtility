using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMDUtility
{
    abstract class PromptAnimation
    {
        protected TextWriter textWriter;

        protected bool isRunning = false;

        protected float completeness = 0;

        public float Сompleteness
        {
            get
            {
                return completeness;
            }
            set
            {
                if (value < 0 && value <= 1)
                {
                    completeness = 0;
                }
                else if (value > 1)
                {
                    completeness = 1;
                }
                else
                {
                    completeness = value;
                }
            }
        }

        public PromptAnimation(TextWriter writer)
        {
            textWriter = writer;
        }

        public abstract void Start();

        public abstract void Stop();
    }
}
