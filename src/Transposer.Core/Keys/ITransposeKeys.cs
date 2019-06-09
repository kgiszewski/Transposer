using System.Collections.Generic;
using Transposer.Core.Notes;

namespace Transposer.Core.Keys
{
    public interface ITransposeKeys
    {
        IEnumerable<INote> Transpose(IList<INote> sourceKey, INote targetKey);
    }
}
