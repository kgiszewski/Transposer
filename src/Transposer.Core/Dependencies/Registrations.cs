using Microsoft.Extensions.DependencyInjection;
using Transposer.Core.Keys;
using Transposer.Core.Notes;

namespace Transposer.Core.Dependencies
{
    public class Registrations
    {
        public static void Register(IServiceCollection container)
        {
            container.AddTransient<IGenerateKeys, KeyGenerator>();
            container.AddTransient<ITransposeKeys, KeyTransposer>();
            container.AddSingleton<AllPitches>();
        }
    }
}
