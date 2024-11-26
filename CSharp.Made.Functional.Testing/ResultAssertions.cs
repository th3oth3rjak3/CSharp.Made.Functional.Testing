using FluentAssertions;

namespace Functional.Testing;

public static partial class Prelude
{
    /// <summary>
    /// Assert that a result is an Ok variant.
    /// </summary>
    /// <typeparam name="Ok">The type when ok.</typeparam>
    /// <typeparam name="Error">The type when error.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The unwrapped value for method chaining.</returns>
    public static Ok AssertOk<Ok, Error>(this Result<Ok, Error> result, string? because = null) =>
        result
            .Tap(r =>
                r.IsOk
                .Should()
                .BeTrue(because ?? "the result was expected to be Ok."))
            .Unwrap();

    /// <summary>
    /// Assert that a result is an Ok variant.
    /// </summary>
    /// <typeparam name="Ok">The type when ok.</typeparam>
    /// <typeparam name="Error">The type when error.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The unwrapped value for method chaining.</returns>
    public static async Task<Ok> AssertOkAsync<Ok, Error>(this Task<Result<Ok, Error>> result, string? because = null) =>
        await result.PipeAsync(r => r.AssertOk(because));

    /// <summary>
    /// Assert that a result is an Error variant.
    /// </summary>
    /// <typeparam name="Ok">The type when ok.</typeparam>
    /// <typeparam name="Error">The type when error.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The unwrapped error for method chaining.</returns>
    public static Error AssertError<Ok, Error>(this Result<Ok, Error> result, string? because = null) =>
        result
            .Tap(r =>
                r.IsError
                .Should()
                .BeTrue(because ?? "the result was expected to be an Error."))
            .UnwrapError();

    /// <summary>
    /// Assert that a result is an Error variant.
    /// </summary>
    /// <typeparam name="Ok">The type when ok.</typeparam>
    /// <typeparam name="Error">The type when error.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The unwrapped error for method chaining.</returns>
    public static async Task<Error> AssertErrorAsync<Ok, Error>(this Task<Result<Ok, Error>> result, string? because = null) =>
        await result.PipeAsync(r => r.AssertError(because));

}
