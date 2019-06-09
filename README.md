# Transposer

A simple dot net core app that can generate all modes of music scales and transpose them.

## Examples

```
//given a root note and a mode, generate a scale
var sut = _serviceProvider.GetService<IGenerateScales>();

var result = sut.Generate(new C(), Mode.Ionian);

var expectedResult = new List<INote>
{
    new C(),
    new D(),
    new E(),
    new F(),
    new G(),
    new A(),
    new B(),
    new C()
};

Assert.AreEqual(expectedResult, result);
```
      
### Transpose

```
//given C major, transpose to A major
var sut = _serviceProvider.GetService<ITransposeScales>();

var result = sut.Transpose(sourceScale, new A());

//A – B – C# – D – E – F# – G# – A
var expectedResult = new List<INote>
{
    new A(),
    new B(),
    new CSharp(),
    new D(),
    new E(),
    new FSharp(),
    new GSharp(),
    new A()
};

Assert.AreEqual(expectedResult, result);
```
