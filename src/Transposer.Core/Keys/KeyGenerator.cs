using System.Collections.Generic;
using System.Linq;
using Transposer.Core.Enums;
using Transposer.Core.Notes;

namespace Transposer.Core.Keys
{
    public class KeyGenerator : IGenerateKeys
    {
        private readonly AllPitches _allPitches;

        public KeyGenerator(
            AllPitches allPitches    
        )
        {
            _allPitches = allPitches;
        }

        public IEnumerable<INote> Generate(INote rootNote, Mode mode = Mode.Ionian)
        {
            //generate the major (Ionian) regardless of the mode
            var allPitches = _allPitches.Notes;
            var major = new List<INote>();

            var pattern = new List<Step>
            {
                Step.Whole,
                Step.Whole,
                Step.Half,
                Step.Whole,
                Step.Whole,
                Step.Whole,
                Step.Half
            };

            //initialize the starting index
            var index = allPitches.IndexOf(rootNote);

            major.Add(allPitches[index]);

            foreach (var stepSize in pattern)
            {
                index += (int)stepSize;

                if (index == allPitches.Count)
                {
                    index = stepSize == Step.Whole ? 0 : 1;
                }

                if (index == allPitches.Count - 1)
                {
                    index = stepSize == Step.Whole ? 1 : 0;
                }

                major.Add(allPitches[index]);
            }

            return _shift(major, (int) mode);
        }

        private IEnumerable<INote> _shift(IList<INote> majorKey, int shiftBy)
        {
            for (var i = 0; i < shiftBy; i++)
            {
                var valueToMove = majorKey.ElementAt(1);

                majorKey.RemoveAt(0);

                majorKey.Add(valueToMove);
            }

            return majorKey;
        }
    }
}
