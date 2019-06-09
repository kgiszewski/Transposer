﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Transposer.Core.Dependencies;
using Transposer.Core.Keys;
using Transposer.Core.Notes;

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
        public void Can_Transpose_Key()
        {
            var keyGenerator = _serviceProvider.GetService<IGenerateKeys>();

            var sourceKey = keyGenerator.Generate(new C()).ToList();

            var sut = _serviceProvider.GetService<ITransposeKeys>();

            var result = sut.Transpose(sourceKey, new A());

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

            result = sut.Transpose(sourceKey, new FSharp());

            //F♯, G♯, A♯, B, C♯, D♯, and E♯
            expectedResult = new List<INote>
            {
                new FSharp(),
                new GSharp(),
                new BFlat(),
                new B(),
                new CSharp(),
                new EFlat(),
                new F(),
                new FSharp()
            };

            Assert.AreEqual(expectedResult.ToList(), result.ToList());
        }
    }
}