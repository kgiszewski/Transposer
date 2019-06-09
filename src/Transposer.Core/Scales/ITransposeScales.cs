using System.Collections.Generic;
using Transposer.Core.Notes;

namespace Transposer.Core.Scales
{
    public interface ITransposeScales
    {
        IEnumerable<INote> Transpose(IList<INote> sourceScale, INote targetKey);
    }
}
