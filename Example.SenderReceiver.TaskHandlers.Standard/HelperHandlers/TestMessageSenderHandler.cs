using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Extensions;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using Example.SenderReceiver.TaskHandlers.Common.Messages;
using System.Threading.Tasks;

namespace Example.SenderReceiver.TaskHandlers.Standard.HelperHandlers
{
    public class TestMessageSenderHandler : TaskHandlerBase, ITaskHandler
    {
        private TestMessageSenderSettings _settings;
        public override string Name { get; } = nameof(TestMessageSenderHandler);

        public override void Initialize(IBindingInfo configuration)
        {
            base.Initialize(configuration);

            _settings = new TestMessageSenderSettings(configuration);

            Validate(_settings);
        }

        private void Validate(TestMessageSenderSettings settings)
        {
            new TestMessageSenderSettingsValidator().ValidateAndThrowPropertyBindingException(settings);
        }

        public override async Task StartAsync()
        {
            var message = new Message<string>(_settings.StringMessage);
            await InvokeNext(message);
        }
    }
}
