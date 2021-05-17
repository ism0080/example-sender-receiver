using System;
using System.Collections.Generic;
using System.Text;

namespace Example.SenderReceiver.Configurations
{
    public class Pipeline
    {
        public string Name { get; set; }
        public Handler[] Handlers { get; set; }
    }
}
