using System.Collections.Generic;
using Transposer.Core.Enums;
using Transposer.Core.Notes;

namespace Transposer.Core.Keys
{
    public interface IGenerateKeys
    {
        IEnumerable<INote> Generate(INote rootNote, Mode mode = Mode.Ionian);
    }
}
