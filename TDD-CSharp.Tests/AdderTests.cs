using TDD_CSharp.Sources.RetweetCollection;

namespace TDD_CSharp.Tests;

public class AdderTests
{
    public static IEnumerable<object[]> SumCases =>
        new List<object[]>
        {
            new object[] { new SumCase(1, 1, 2) },
            new object[] { new SumCase(1, 2, 3) },
            new object[] { new SumCase(2, 2, 4) }
        };

    [Theory]
    [MemberData(nameof(SumCases))]
    public void GeneratesLotsOfSumsFromTwoNumbers(SumCase input)
    {
        Assert.Equal(input.Expected, Adder.Sum(input.A, input.B));
    }
}

public class SumCase
{
    public int A { get; }
    public int B { get; }
    public int Expected { get; }

    public SumCase(int a, int b, int expected)
    {
        A = a;
        B = b;
        Expected = expected;
    }
}