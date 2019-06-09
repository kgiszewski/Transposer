using System;
using Microsoft.Extensions.DependencyInjection;
using Transposer.Core.Dependencies;

namespace Transposer.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = new ServiceCollection();

            Registrations.Register(container);

            Console.WriteLine("Hello World!");
        }
    }
}
