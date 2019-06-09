using System.Collections.Generic;
using System.Linq;
using Transposer.Core.Enums;
using Transposer.Core.Notes;

namespace Transposer.Core.Scales
{
    public class ScaleGenerator : IGenerateScales
    {
        private readonly AllPitches _allPitches;

        public ScaleGenerator(
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

        private IEnumerable<INote> _shift(IList<INote> majorScale, int shiftBy)
        {
            for (var i = 0; i < shiftBy; i++)
            {
                var valueToMove = majorScale.ElementAt(1);

                majorScale.RemoveAt(0);

                majorScale.Add(valueToMove);
            }

            return majorScale;
        }
    }
}
