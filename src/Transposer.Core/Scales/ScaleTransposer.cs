using System.Collections.Generic;
using System.Linq;
using Transposer.Core.Notes;

namespace Transposer.Core.Scales
{
    public class ScaleTransposer : ITransposeScales
    {
        private readonly AllPitches _allPitches;

        public ScaleTransposer(
            AllPitches allPitches    
        )
        {
            _allPitches = allPitches;
        }

        public IEnumerable<INote> Transpose(IList<INote> sourceScale, INote targetKey)
        {
            var allPitches = _allPitches.Notes;

            var rootNote = sourceScale.First();

            if (rootNote == targetKey)
            {
                return sourceScale;
            }

            var indexOfSourceNote = allPitches.IndexOf(rootNote);
            var indexOfTargetNote = allPitches.IndexOf(targetKey);

            //could be +/-
            var distance = indexOfTargetNote - indexOfSourceNote;

            var result = new List<INote>();

            foreach (var note in sourceScale)
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
