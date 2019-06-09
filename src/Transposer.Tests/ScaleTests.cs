using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Transposer.Core.Dependencies;
using Transposer.Core.Enums;
using Transposer.Core.Notes;
using Transposer.Core.Scales;

namespace Transposer.Tests
{
    [TestFixture]
    public class ScaleTests
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
        public void Can_Generate_Scale()
        {
            var sut = _serviceProvider.GetService<IGenerateScales>();

            var result = sut.Generate(new C(), Mode.Ionian);

            var expectedResult = new List<INote>
            {
                new C(),
                new D(),
                new E(),
                new F(),
                new G(),
                new A(),
                new B(),
                new C()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Dorian);

            expectedResult = new List<INote>
            {
                new D(),
                new E(),
                new F(),
                new G(),
                new A(),
                new B(),
                new C(),
                new D()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Phrygian);

            expectedResult = new List<INote>
            {
                new E(),
                new F(),
                new G(),
                new A(),
                new B(),
                new C(),
                new D(),
                new E()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Lydian);

            expectedResult = new List<INote>
            {
                new F(),
                new G(),
                new A(),
                new B(),
                new C(),
                new D(),
                new E(),
                new F()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Mixolydian);

            expectedResult = new List<INote>
            {
                new G(),
                new A(),
                new B(),
                new C(),
                new D(),
                new E(),
                new F(),
                new G()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Aeolian);

            expectedResult = new List<INote>
            {
                new A(),
                new B(),
                new C(),
                new D(),
                new E(),
                new F(),
                new G(),
                new A()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Generate(new C(), Mode.Locrian);

            expectedResult = new List<INote>
            {
                new B(),
                new C(),
                new D(),
                new E(),
                new F(),
                new G(),
                new A(),
                new B()
            };

            Assert.AreEqual(expectedResult, result);
        }
    }
}
