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
    public async Task AssertOkAsync_WhenOk_ShouldPass()
    {
        Result<int, string> value = 1;
        (await value
            .Async()
            .AssertOkAsync())
            .Should()
            .Be(1);
    }

    [Fact]
    public async Task AssertOkAsync_WhenError_ShouldFail()
    {
        Result<int, string> value = "error";
        await value
            .Invoking(v => v.Async().AssertOkAsync())
            .Should()
            .ThrowAsync<XunitException>();
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
    public async Task AssertErrorAsync_WhenError_ShouldPass()
    {
        Result<int, string> value = "error";
        (await value
            .Async()
            .AssertErrorAsync())
            .Should()
            .Be("error");
    }

    [Fact]
    public async Task AssertErrorAsync_WhenOk_ShouldFail()
    {
        Result<int, string> value = 1;
        await value
            .Invoking(v => v.Async().AssertErrorAsync())
            .Should()
            .ThrowAsync<XunitException>();
    }
}