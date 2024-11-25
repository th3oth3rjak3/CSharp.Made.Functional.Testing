namespace Functional.Testing.UnitTests;

public class OptionAssertionTests
{
    [Fact]
    public void AssertSome_ShouldPass_WhenSome()
    {
        Option<int> option = 1;
        option.AssertSome()
            .Should()
            .Be(1);
    }

    [Fact]
    public void AssertSome_ShouldFail_WhenNone()
    {
        Option<int> option = None<int>();
        option
            .Invoking(o => o.AssertSome())
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertNone_ShouldPass_WhenNone()
    {
        Option<int> option = None<int>();
        option
            .AssertNone()
            .Should()
            .Be(Unit());
    }

    [Fact]
    public void AssertNone_ShouldFail_WhenSome()
    {
        Option<int> option = 1;
        option
            .Invoking(o => o.AssertNone())
            .Should()
            .Throw<XunitException>();
    }
}
