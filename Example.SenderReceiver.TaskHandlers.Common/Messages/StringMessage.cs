using System;
using System.Collections.Generic;
using System.Text;

namespace Example.SenderReceiver.TaskHandlers.Common.Messages
{
    public class StringMessage : Message<string>
    {
        public StringMessage(string message, string correlationId) : base(message, correlationId) { }

        public override string ToString()
        {
            return Body;
        }
    }
}
