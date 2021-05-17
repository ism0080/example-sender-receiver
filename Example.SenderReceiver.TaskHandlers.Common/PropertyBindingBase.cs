using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using System;
using System.Linq;

namespace Example.SenderReceiver.TaskHandlers.Common
{
    public abstract class PropertyBindingBase<T>
    {
        private readonly IBindingInfo _info;

        protected PropertyBindingBase(IBindingInfo info)
        {
            _info = info;
        }

        public TProperty TryGet<TProperty>(string name)
        {
            try
            {
                return (TProperty)Convert.ChangeType(_info.Props.First(x => x.Key == name).Value, typeof(TProperty));
            }
            catch
            {
                // ignored
            }
            return default;
        }

        public TProperty GetWithDefault<TProperty>(string name, TProperty defaultValue)
        {
            try
            {
                var value = _info.Props.FirstOrDefault(x => x.Key == name);
                if (value == null) return defaultValue;
                return (TProperty)Convert.ChangeType(_info.Props.First(x => x.Key == name).Value, typeof(TProperty));
            }
            catch
            {
                // ignored
            }

            return default;
        }
    }
}
