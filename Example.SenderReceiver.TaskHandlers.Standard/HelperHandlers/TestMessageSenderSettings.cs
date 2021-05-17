using Example.SenderReceiver.TaskHandlers.Common;
using Example.SenderReceiver.TaskHandlers.Common.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.SenderReceiver.TaskHandlers.Standard.HelperHandlers
{
    public class TestMessageSenderSettings : PropertyBindingBase<TestMessageSenderSettings>
    {
        public TestMessageSenderSettings(IBindingInfo info) : base(info) { }

        public string StringMessage => TryGet<string>(nameof(StringMessage));
    }

    public class TestMessageSenderSettingsValidator : AbstractValidator<TestMessageSenderSettings>
    {
        public TestMessageSenderSettingsValidator()
        {
            RuleFor(settings => settings.StringMessage).NotEmpty();
        }
    }
}
