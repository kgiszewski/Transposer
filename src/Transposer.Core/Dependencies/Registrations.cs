using Microsoft.Extensions.DependencyInjection;
using Transposer.Core.Keys;

namespace Transposer.Core.Dependencies
{
    public class Registrations
    {
        public static void Register(IServiceCollection container)
        {
            container.AddTransient<IGenerateKeys, KeyGenerator>();
        }
    }
}
