using System.Collections.Generic;
using Transposer.Core.Notes;

namespace Transposer.Core.Keys
{
    public interface IGenerateKeys
    {
        IEnumerable<INote> Generate(INote rootNote);
    }
}
