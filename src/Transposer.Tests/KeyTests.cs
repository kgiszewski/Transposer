using System;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Transposer.Core.Dependencies;
using Transposer.Core.Keys;

namespace Transposer.Tests
{
    [TestFixture]
    public class KeyTests
    {
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Init()
        {
            var container = new ServiceCollection();

            Registrations.Register(container);

            _serviceProvider = container.BuildServiceProvider();
        }

        [Test]
        public void Can_Generate_Key()
        {
            var sut = _serviceProvider.GetService<IGenerateKeys>();


        }
    }
}
