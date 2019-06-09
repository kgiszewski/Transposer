using System.Collections.Generic;
using System.Linq;
using Transposer.Core.Notes;

namespace Transposer.Core.Keys
{
    public class KeyTransposer : ITransposeKeys
    {
        private readonly AllPitches _allPitches;

        public KeyTransposer(
            AllPitches allPitches    
        )
        {
            _allPitches = allPitches;
        }

        public IEnumerable<INote> Transpose(IList<INote> sourceKey, INote targetKey)
        {
            var allPitches = _allPitches.Notes;

            var rootNote = sourceKey.First();

            if (rootNote == targetKey)
            {
                return sourceKey;
            }

            var indexOfSourceNote = allPitches.IndexOf(rootNote);
            var indexOfTargetNote = allPitches.IndexOf(targetKey);

            //could be +/-
            var distance = indexOfTargetNote - indexOfSourceNote;

            var result = new List<INote>();

            foreach (var note in sourceKey)
            {
                var indexOfNote = allPitches.IndexOf(note);

                var newIndex = indexOfNote + distance;

                if (newIndex < 0)
                {
                    newIndex = allPitches.Count + newIndex;
                }

                if (newIndex > allPitches.Count)
                {
                    newIndex = newIndex - allPitches.Count;
                }

                result.Add(allPitches[newIndex]);
            }

            return result;
        }
    }
}
