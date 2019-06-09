using System.Collections.Generic;

namespace Transposer.Core.Notes
{
    public class AllPitches
    {
        public List<INote> Notes =>
            new List<INote>
            {
                new A(),
                new BFlat(),
                new B(),
                new C(),
                new CSharp(),
                new D(),
                new EFlat(),
                new E(),
                new F(),
                new FSharp(),
                new G(),
                new GSharp()
            };
    }
}
