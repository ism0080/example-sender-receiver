using System;
using System.Collections.Generic;
using System.Text;

namespace Example.SenderReceiver.TaskHandlers.Common.Messages
{
    public class ByteMessage : Message<byte[]>
    {
        public ByteMessage(byte[] message) : base(message) { }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(Body);
        }
    }
}
