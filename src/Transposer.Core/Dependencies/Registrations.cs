using Microsoft.Extensions.DependencyInjection;
using Transposer.Core.Notes;
using Transposer.Core.Scales;

namespace Transposer.Core.Dependencies
{
    public class Registrations
    {
        public static void Register(IServiceCollection container)
        {
            container.AddTransient<IGenerateScales, ScaleGenerator>();
            container.AddTransient<ITransposeScales, ScaleTransposer>();
            container.AddSingleton<AllPitches>();
        }
    }
}
