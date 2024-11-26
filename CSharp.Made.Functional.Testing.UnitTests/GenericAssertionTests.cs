namespace CSharp.Made.Functional.Testing.UnitTests;
public class GenericAssertionTests
{
    internal class TestModel
    {
        public int Value { get; set; }
        public string? Message { get; set; }
    }

    [Fact]
    public void AssertTrue_ShouldBeTrue_WhenPredicateIsTrue()
    {
        var value = 1;

        value
            .Invoking(v => v.AssertTrue(i => i == 1))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertTrue_ShouldBeTrue_WhenInputIsTrue()
    {
        var value = true;
        value
            .Invoking(value => value.AssertTrue())
            .Should()
            .NotThrow();
    }

    [Fact]
    public async Task AssertTrueAsync_ShouldBeTrue_WhenPredicateIsTrue()
    {
        var value = 1;

        await value
            .Invoking(v => v.Async().AssertTrueAsync(i => i == 1))
            .Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task AssertTrueAsync_ShouldBeTrue_WhenInputIsTrue()
    {
        var value = true;
        await value
            .Invoking(value => value.Async().AssertTrueAsync())
            .Should()
            .NotThrowAsync();
    }

    [Fact]
    public void AssertTrue_ShouldThrow_WhenPredicateIsFalse()
    {
        var value = 1;
        value
            .Invoking(v => v.AssertTrue(i => i == 2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public void AssertTrue_ShouldThrow_WhenValueIsFalse()
    {
        var value = false;
        value
            .Invoking(v => v.AssertTrue())
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertTrueAsync_ShouldThrow_WhenPredicateIsFalse()
    {
        var value = 1;
        await value
            .Invoking(v => v.Async().AssertTrueAsync(i => i == 2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public async Task AssertTrueAsync_ShouldThrow_WhenValueIsFalse()
    {
        var value = false;
        await value
            .Invoking(v => v.Async().AssertTrueAsync())
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldBeFalse_WhenPredicateIsFalse()
    {
        var value = 1;
        value
            .Invoking(v => v.AssertFalse(i => i == 2))
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertFalse_ShouldThrow_WhenPredicateIsTrue()
    {
        var value = 1;
        value
            .Invoking(v => v.AssertFalse(i => i == 1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertFalseAsync_WhenSome_ShouldBeFalse_WhenPredicateIsFalse()
    {
        var value = 1;
        await value
            .Invoking(v => v.Async().AssertFalseAsync(i => i == 2))
            .Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task AssertFalseAsync_ShouldThrow_WhenPredicateIsTrue()
    {
        var value = 1;
        await value
            .Invoking(v => v.Async().AssertFalseAsync(i => i == 1))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldNotThrow_WhenValueIsFalse()
    {
        var value = false;
        value
            .Invoking(v => v.AssertFalse())
            .Should()
            .NotThrow();
    }

    [Fact]
    public void AssertFalse_WhenSome_ShouldThrow_WhenValueIsTrue()
    {
        var value = true;
        value
            .Invoking(v => v.AssertFalse())
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertFalseAsync_WhenSome_ShouldNotThrow_WhenValueIsFalse()
    {
        var value = false;
        await value
            .Invoking(v => v.Async().AssertFalseAsync())
            .Should()
            .NotThrowAsync();
    }

    [Fact]
    public async Task AssertFalseAsync_WhenSome_ShouldThrow_WhenValueIsTrue()
    {
        var value = true;
        await value
            .Invoking(v => v.Async().AssertFalseAsync())
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertEqual_ShouldPass_WhenObjectsAreEqual()
    {
        var value1 = new { Random = "something random" };

        value1.AssertEqual(value1)
            .Should()
            .Be(value1);
    }

    [Fact]
    public void AssertEqual_ShouldFail_WhenObjectsAreNotEqual()
    {
        var value1 = new object();
        var value2 = new object();

        value1
            .Invoking(v => v.AssertEqual(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertEqualAsync_ShouldPass_WhenObjectsAreEqual()
    {
        var value1 = new { Random = "something random" };

        (await value1
            .Async()
            .AssertEqualAsync(value1))
            .Should()
            .Be(value1);
    }

    [Fact]
    public async Task AssertEqualAsync_ShouldFail_WhenObjectsAreNotEqual()
    {
        var value1 = new object();
        var value2 = new object();

        await value1
            .Invoking(v => v.Async().AssertEqualAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertNotEqual_ShouldPass_WhenObjectsAreNotEqual()
    {
        var value1 = new object();
        var value2 = new object();

        value1
            .AssertNotEqual(value2)
            .Should()
            .Be(value1);
    }

    [Fact]
    public void AssertNotEqual_ShouldFail_WhenObjectsAreEqual()
    {
        var value1 = new object();

        value1
            .Invoking(v => v.AssertNotEqual(value1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertNotEqualAsync_ShouldPass_WhenObjectsAreNotEqual()
    {
        var value1 = new object();
        var value2 = new object();

        (await value1
            .Async()
            .AssertNotEqualAsync(value2))
            .Should()
            .Be(value1);
    }

    [Fact]
    public async Task AssertNotEqualAsync_ShouldFail_WhenObjectsAreEqual()
    {
        var value1 = new object();

        await value1
            .Invoking(v => v.Async().AssertNotEqualAsync(value1))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertEquivalent_ShouldPass_WhenObjectsAreEquivalent()
    {

        var value1 = new TestModel { Message = "hello", Value = 1 };
        var value2 = new TestModel { Value = 1, Message = "hello" };

        value1
            .AssertEquivalent(value2)
            .Should()
            .Be(value1);
    }

    [Fact]
    public void AssertEquivalent_ShouldFail_WhenObjectsAreNotEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 2 };

        value1
            .Invoking(v => v.AssertEquivalent(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertEquivalentAsync_ShouldPass_WhenObjectsAreEquivalent()
    {

        var value1 = new TestModel { Message = "hello", Value = 1 };
        var value2 = new TestModel { Value = 1, Message = "hello" };

        (await value1
            .Async()
            .AssertEquivalentAsync(value2))
            .Should()
            .Be(value1);
    }

    [Fact]
    public async Task AssertEquivalentTask_ShouldFail_WhenObjectsAreNotEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 2 };

        await value1
            .Invoking(v => v.Async().AssertEquivalentAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertNotEquivalent_ShouldPass_WhenObjectsAreNotEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 2 };

        value1
            .AssertNotEquivalent(value2)
            .Should()
            .Be(value1);
    }

    [Fact]
    public void AssertNotEquivalent_ShouldFail_WhenObjectsAreEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 1 };

        value1
            .Invoking(v => v.AssertNotEquivalent(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertNotEquivalentAsync_ShouldPass_WhenObjectsAreNotEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 2 };

        (await value1
            .Async()
            .AssertNotEquivalentAsync(value2))
            .Should()
            .Be(value1);
    }

    [Fact]
    public async Task AssertNotEquivalentAsync_ShouldFail_WhenObjectsAreEquivalent()
    {
        var value1 = new TestModel { Message = "a message", Value = 1 };
        var value2 = new TestModel { Message = "a message", Value = 1 };

        await value1
            .Invoking(v => v.Async().AssertNotEquivalentAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertEqual_ShouldPass_WhenCollectionsAreEqual()
    {
        List<string> value1 = ["hello", "world"];

        value1
            .AssertEqual(value1)
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public void AssertEqual_ShouldNotPass_WhenCollectionsAreNotEqual()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["hello", "world"];

        value1
            .Invoking(v => v.AssertEqual(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertEqualAsync_ShouldPass_WhenCollectionsAreEqual()
    {
        List<string> value1 = ["hello", "world"];

        var values = await value1
            .Async()
            .AssertEqualAsync(value1);

        values
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public async Task AssertEqualAsync_ShouldNotPass_WhenCollectionsAreNotEqual()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["hello", "world"];

        await value1
            .Invoking(v => v.Async().AssertEqualAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertNotEqual_ShouldPass_WhenCollectionsAreNotEqual()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["hello", "world"];

        value1
            .AssertNotEqual(value2)
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public void AssertNotEqual_ShouldNotPass_WhenCollectionsNotEqual()
    {
        List<string> value1 = ["hello", "world"];

        value1
            .Invoking(v => v.AssertNotEqual(value1))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertNotEqualAsync_ShouldPass_WhenCollectionsAreNotEqual()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["hello", "world"];

        var values = await value1
            .Async()
            .AssertNotEqualAsync(value2);

        values
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public async Task AssertNotEqualAsync_ShouldNotPass_WhenCollectionsNotEqual()
    {
        List<string> value1 = ["hello", "world"];

        await value1
            .Invoking(v => v.Async().AssertNotEqualAsync(value1))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertEquivalent_ShouldPass_WhenCollectionsAreEquivalent()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["world", "hello"];

        value1
            .AssertEquivalent(value2)
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public void AssertEquivalent_ShouldFail_WhenCollectionsAreNotEquivalent()
    {
        List<string> value1 = ["hello", "WORLD"];
        List<string> value2 = ["world", "hello"];

        value1
            .Invoking(v => v.AssertEquivalent(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertEquivalentAsync_ShouldPass_WhenCollectionsAreEquivalent()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["world", "hello"];

        var values = await value1
            .Async()
            .AssertEquivalentAsync(value2);

        values
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public async Task AssertEquivalentAsync_ShouldFail_WhenCollectionsAreNotEquivalent()
    {
        List<string> value1 = ["hello", "WORLD"];
        List<string> value2 = ["world", "hello"];

        await value1
            .Invoking(v => v.Async().AssertEquivalentAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

    [Fact]
    public void AssertNotEquivalent_ShouldPass_WhenCollectionsAreNotEquivalent()
    {
        List<string> value1 = ["hello", "WORLD"];
        List<string> value2 = ["world", "hello"];

        value1
            .AssertNotEquivalent(value2)
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public void AssertNotEquivalent_Should_Fail_WhenCollectionsAreEquivalent()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["world", "hello"];

        value1
            .Invoking(v => v.AssertNotEquivalent(value2))
            .Should()
            .Throw<XunitException>();
    }

    [Fact]
    public async Task AssertNotEquivalentAsync_ShouldPass_WhenCollectionsAreNotEquivalent()
    {
        List<string> value1 = ["hello", "WORLD"];
        List<string> value2 = ["world", "hello"];

        var values = await value1
            .Async()
            .AssertNotEquivalentAsync(value2);

        values
            .Should()
            .ContainInOrder(value1);
    }

    [Fact]
    public async Task AssertNotEquivalentAsync_Should_Fail_WhenCollectionsAreEquivalent()
    {
        List<string> value1 = ["hello", "world"];
        List<string> value2 = ["world", "hello"];

        await value1
            .Invoking(v => v.Async().AssertNotEquivalentAsync(value2))
            .Should()
            .ThrowAsync<XunitException>();
    }

}