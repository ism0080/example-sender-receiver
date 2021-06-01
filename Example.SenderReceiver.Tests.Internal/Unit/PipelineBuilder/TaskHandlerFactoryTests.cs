using System;
using System.Collections.Generic;
using System.Text;
using Example.SenderReceiver.Configurations;
using Example.SenderReceiver.PipelineBuilder;
using Example.SenderReceiver.PipelineBuilder.Interfaces;
using Example.SenderReceiver.Tests.Internal.Unit.TestHandlers;
using Shouldly;
using Xunit;

namespace Example.SenderReceiver.Tests.Internal.Unit.PipelineBuilder
{
    public class TaskHandlerFactoryTests
    {
        [Fact]
        public void TaskHandlerFactoryShouldCreateInstancesOfHandlers()
        {
            var taskHandlers = new[] { new MessageGeneratorHandler() };
            var taskHandlerFactory = new TaskHandlerFactory<Handler>(taskHandlers);
            IHandlerConfiguration<Handler> configuration = new Handler { Name = nameof(MessageGeneratorHandler) };
            var handler = taskHandlerFactory.Get(configuration);
            handler.ShouldNotBeNull();
        }

        [Fact]
        public void TaskHandlerFactoryShouldThrowHandlerNotFoundException()
        {
            var taskHandlers = new[] { new MessageGeneratorHandler() };
            var taskHandlerFactory = new TaskHandlerFactory<Handler>(taskHandlers);
            IHandlerConfiguration<Handler> configuration = new Handler { Name = "unavailabletask" };
            Assert.Throws<Exception>(() => taskHandlerFactory.Get(configuration));
        }
    }
}
