using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Transposer.Core.Dependencies;
using Transposer.Core.Notes;
using Transposer.Core.Scales;

namespace Transposer.Tests
{
    [TestFixture]
    public class TransposerTests
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
        public void Can_Transpose_Scale()
        {
            var scaleGenerator = _serviceProvider.GetService<IGenerateScales>();

            var sourceScale = scaleGenerator.Generate(new C()).ToList();

            var sut = _serviceProvider.GetService<ITransposeScales>();

            var result = sut.Transpose(sourceScale, new A());

            //A – B – C# – D – E – F# – G# – A
            var expectedResult = new List<INote>
            {
                new A(),
                new B(),
                new CSharp(),
                new D(),
                new E(),
                new FSharp(),
                new GSharp(),
                new A()
            };

            Assert.AreEqual(expectedResult, result);

            result = sut.Transpose(sourceScale, new FSharp());

            //F♯, G♯, A♯, B, C♯, D♯, and E♯
            expectedResult = sut.Transpose(sourceScale, new FSharp()).ToList();

            Assert.AreEqual(expectedResult.ToList(), result.ToList());
        }
    }
}
