namespace Functional.Testing;

using FluentAssertions;

public static partial class Prelude
{
    public static void AssertTrue_WhenSome<T>(this Option<T> option, Func<T, bool> predicate, string? because = null)
    {
        var someValue = option.Unwrap();

        predicate(someValue)
            .Should()
            .BeTrue(because ?? "the predicate was expected to be true");
    }

    public static void AssertFalse_WhenSome<T>(this Option<T> option, Func<T, bool> predicate, string? because = null)
    {
        var someValue = option.Unwrap();

        predicate(someValue)
            .Should()
            .BeFalse(because ?? "the predicate was expected to be false");
    }

    public static void AssertNone<T>(this Option<T> option, string? because = null)
    {
        option
            .IsNone
            .Should()
            .BeTrue(because ?? "the option was expected to be None");
    }
}
