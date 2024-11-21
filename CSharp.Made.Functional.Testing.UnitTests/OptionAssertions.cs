namespace Functional.Testing.UnitTests;

using FluentAssertions;

using Functional;

using Xunit.Sdk;

public class OptionAssertions
{
    [Fact]
    public void AssertTrue_WhenSome_ShouldBeTrue_WhenPredicateIsTrue()
    {
        Option<int> value = 1;

        value
            .Invoking(v => v.AssertTrue_WhenSome(i => i == 1))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertTrue_WhenSome_ShouldThrow_WhenPredicateIsFalse()
    {
        Option<int> value = 1;
        value
            .Invoking(v => v.AssertTrue_WhenSome(i => i == 2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertTrue_WhenSome_ShouldThrow_WhenValueIsNone()
    {
        Option<int> value = new();
        value
            .Invoking(v => v.AssertTrue_WhenSome(i => i == 1))
            .Should()
            .Throw<OptionUnwrapException>();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldBeFalse_WhenPredicateIsFalse()
    {
        Option<int> value = 1;
        value
            .Invoking(v => v.AssertFalse_WhenSome(i => i == 2))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldThrow_WhenPredicateIsTrue()
    {
        Option<int> value = 1;
        value
            .Invoking(v => v.AssertFalse_WhenSome(i => i == 1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldThrow_WhenOptionIsNone()
    {
        Option<int> value = new();
        value
            .Invoking(v => v.AssertFalse_WhenSome(i => i == 2))
            .Should()
            .Throw<OptionUnwrapException>();
    }

    [Fact]
    public void AssertNone_ShouldNotThrow_WhenOptionIsNone()
    {
        Option<int> value = new();
        value
            .Invoking(v => v.AssertNone())
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertNone_ShouldThrow_WhenOptionIsSome()
    {
        Option<int> value = 1;
        value
            .Invoking(v => v.AssertNone())
            .Should()
            .Throw<XunitException>();
    }
}
