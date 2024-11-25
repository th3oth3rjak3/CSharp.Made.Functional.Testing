namespace Functional.Testing.UnitTests;

public class ResultAssertionTests
{
    [Fact]
    public void AssertOk_WhenOk_ShouldPass()
    {
        Result<int, string> value = 1;
        value
            .AssertOk()
            .Should()
            .Be(1);
    }

    [Fact]
    public void AssertOk_WhenError_ShouldFail()
    {
        Result<int, string> value = "error";
        value
            .Invoking(v => v.AssertOk())
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertError_WhenError_ShouldPass()
    {
        Result<int, string> value = "error";
        value
            .AssertError()
            .Should()
            .Be("error");
    }

    [Fact]
    public void AssertError_WhenOk_ShouldFail()
    {
        Result<int, string> value = 1;
        value
            .Invoking(v => v.AssertError())
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertTrue_WhenOk_ShouldBeTrue_WhenPredicateIsTrue()
    {
        Result<int, string> value = 1;

        value
            .Invoking(v => v.AssertTrue_WhenOk(v => v == 1))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertTrue_WhenOk_ShouldThrow_WhenPredicateIsFalse()
    {
        Result<int, string> value = 2;
        value
            .Invoking(v => v.AssertTrue_WhenOk(v => v == 1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertTrue_WhenOk_ShouldThrow_WhenValueIsError()
    {
        Result<int, string> value = "an error";
        value
            .Invoking(v => v.AssertTrue_WhenOk(v => v == 1))
            .Should()
            .Throw<ResultUnwrapException>();
    }

    [Fact]
    public void AssertFalse_WhenOk_ShouldBeTrue_WhenPredicateIsFalse()
    {
        Result<int, string> value = 1;
        value
            .Invoking(v => v.AssertFalse_WhenOk(value => value == 0))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertFalse_WhenOk_ShouldThrow_WhenPredicateIsTrue()
    {
        Result<int, string> value = 1;
        value
            .Invoking(v => v.AssertFalse_WhenOk(value => value == 1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertFalse_WhenOk_ShouldThrow_WhenValueIsError()
    {
        Result<int, string> value = "error message";
        value
            .Invoking(v => v.AssertFalse_WhenOk(i => i == 1))
            .Should()
            .Throw<ResultUnwrapException>();
    }

    [Fact]
    public void AssertTrue_WhenError_ShouldBeTrue_WhenPredicateIsTrue()
    {
        Result<int, string> value = "error message";
        value
            .Invoking(v => v.AssertTrue_WhenError(m => m == "error message"))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertTrue_WhenError_ShouldThrow_WhenPredicateIsFalse()
    {
        Result<int, string> value = "error message";
        value
            .Invoking(v => v.AssertTrue_WhenError(m => m == "error"))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertTrue_WhenError_ShouldThrow_WhenValueIsOk()
    {
        Result<int, string> value = 1;
        value
            .Invoking(v => v.AssertTrue_WhenError(m => m == "error message"))
            .Should()
            .Throw<ResultUnwrapErrorException>();
    }

    [Fact]
    public void AssertFalse_WhenError_ShouldBeFalse_WhenPredicateIsFalse()
    {
        Result<int, string> value = "error message";
        value
            .Invoking(v => v.AssertFalse_WhenError(m => m == "error"))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertFalse_WhenError_ShouldThrow_WhenPredicateIsTrue()
    {
        Result<int, string> value = "error message";
        value
            .Invoking(v => v.AssertFalse_WhenError(m => m == "error message"))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertFalse_WhenError_ShouldThrow_WhenValueIsOk()
    {
        Result<int, string> value = 1;
        value
            .Invoking(v => v.AssertFalse_WhenError(m => m == "an error message"))
            .Should()
            .Throw<ResultUnwrapErrorException>();
    }
}