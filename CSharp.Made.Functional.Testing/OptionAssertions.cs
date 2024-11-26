using FluentAssertions;

using static Functional.Prelude;

namespace Functional.Testing;

public static partial class Prelude
{
    /// <summary>
    /// Assert that an option is a Some variant.
    /// </summary>
    /// <typeparam name="T">The inner type of the option.</typeparam>
    /// <param name="option">The option to check for a Some variant.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The original option for method chaining.</returns>
    public static T AssertSome<T>(this Option<T> option, string? because = null) =>
        option
            .Tap(o =>
                o.IsSome
                .Should()
                .BeTrue(because ?? "the option was expected to be Some."))
            .Unwrap();

    /// <summary>
    /// Assert that an option is a Some variant.
    /// </summary>
    /// <typeparam name="T">The inner type of the option.</typeparam>
    /// <param name="option">The option to check for a Some variant.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The original option for method chaining.</returns>
    public static async Task<T> AssertSomeAsync<T>(this Task<Option<T>> option, string? because = null) =>
        await option.PipeAsync(o => o.AssertSome(because));

    /// <summary>
    /// Assert that an option is a None variant.
    /// </summary>
    /// <typeparam name="T">The inner type of the option.</typeparam>
    /// <param name="option">The option to check for a None variant.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The original option for method chaining.</returns>
    public static Unit AssertNone<T>(this Option<T> option, string? because = null) =>
        option
            .Tap(o =>
                o.IsNone
                .Should()
                .BeTrue(because ?? "the option was expected to be None."))
            .Pipe(() => Unit());

    /// <summary>
    /// Assert that an option is a None variant.
    /// </summary>
    /// <typeparam name="T">The inner type of the option.</typeparam>
    /// <param name="option">The option to check for a None variant.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The original option for method chaining.</returns>
    public static async Task<Unit> AssertNoneAsync<T>(this Task<Option<T>> option, string? because = null) =>
        await option.PipeAsync(o => o.AssertNone(because));
}
