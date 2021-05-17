using System.Collections.Generic;

namespace Example.SenderReceiver.TaskHandlers.Common.Interfaces
{
    public interface IBindingInfo
    {
        List<KeyValuePair> Props { get; set; }
    }
}
