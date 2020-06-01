using System;

namespace Client
{
    internal class MethodInvoker
    {
        private Action msg;

        public MethodInvoker(Action msg)
        {
            this.msg = msg;
        }
    }
}