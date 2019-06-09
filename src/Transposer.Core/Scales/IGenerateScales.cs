using System.Collections.Generic;
using Transposer.Core.Enums;
using Transposer.Core.Notes;

namespace Transposer.Core.Scales
{
    public interface IGenerateScales
    {
        IEnumerable<INote> Generate(INote rootNote, Mode mode = Mode.Ionian);
    }
}
