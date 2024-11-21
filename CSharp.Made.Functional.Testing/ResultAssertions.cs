namespace Functional.Testing;

using System;

using FluentAssertions;

public static partial class Prelude
{
    /// <summary>
    /// Assert that the result is an Ok variant, and that the predicate provided will return true.
    /// <example><br /><br/>
    /// Example:
    /// <code>
    ///     // An Ok variant with the inner value 1.
    ///     var okValue = new Result&lt;int, string&gt;(1);
    ///     
    ///     // This won't throw because the value actually equals 1 and is Ok.
    ///     okValue.AssertTrue_WhenOk(v => v == 1);
    ///     
    ///     // This will throw an exception because the value doesn't equal 2 causing the test to fail.
    ///     okValue.AssertTrue_WhenOk(v => v == 2);
    ///     
    ///     // This is an error variant.
    ///     var error = new Result&lt;int, string&gt;("an error message");
    ///
    ///     // This will throw because it's not Ok causing a test to fail.
    ///     error.AssertTrue_WhenOk(v => v == 1);
    /// </code>
    /// </example>
    /// </summary>
    /// <typeparam name="Ok">The Ok type.</typeparam>
    /// <typeparam name="Error">The Error type.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="predicate">An expression that should be true for the test to pass.</param>
    /// <param name="because">A message that expresses why the assertion should be true for test output.</param>
    public static void AssertTrue_WhenOk<Ok, Error>(this Result<Ok, Error> result, Func<Ok, bool> predicate, string? because = null)
    {
        var okValue = result.Unwrap();

        predicate(okValue)
            .Should()
            .BeTrue(because ?? "the predicate was expected to be true");
    }

    /// <summary>
    /// Assert that the result is an Ok variant, and that the predicate provided will return false.
    /// <example><br /><br/>
    /// Example:
    /// <code>
    ///     // An Ok variant with the inner value 1.
    ///     var okValue = new Result&lt;int, string&gt;(1);
    ///     
    ///     // This won't throw because the value actually equals 1 and is Ok.
    ///     okValue.AssertFalse_WhenOk(v => v == 2);
    ///     
    ///     // This will throw an exception because the value does equal 1 causing the test to fail.
    ///     okValue.AssertFalse_WhenOk(v => v == 1);
    ///     
    ///     // This is an error variant.
    ///     var error = new Result&lt;int, string&gt;("an error message");
    ///
    ///     // This will throw because it's not Ok causing a test to fail.
    ///     error.AssertFalse_WhenOk(v => v == 2);
    /// </code>
    /// </example>
    /// </summary>
    /// <typeparam name="Ok">The Ok type.</typeparam>
    /// <typeparam name="Error">The Error type.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="predicate">An expression that should be false for the test to pass.</param>
    /// <param name="because">A message that expresses why the assertion should be false for test output.</param>
    public static void AssertFalse_WhenOk<Ok, Error>(this Result<Ok, Error> result, Func<Ok, bool> predicate, string? because = null)
    {
        var okValue = result.Unwrap();

        predicate(okValue)
            .Should()
            .BeFalse(because ?? "the predicate was expected to be false");
    }

    /// <summary>
    /// Assert that the result is an Error variant, and that the predicate provided will return true.
    /// <example><br /><br/>
    /// Example:
    /// <code>
    ///     // An Error variant with the inner value "an error message".
    ///     var error = new Result&lt;int, string&gt;("an error message");
    ///     
    ///     // This won't throw because the value actually equals "an error message" and is an Error variant.
    ///     error.AssertTrue_WhenError(m => m == "an error message");
    ///     
    ///     // This will throw an exception because the value doesn't equal "an error message" causing the test to fail.
    ///     error.AssertTrue_WhenError(m => m == "a different message");
    ///     
    ///     // This is an Ok variant.
    ///     var okValue = new Result&lt;int, string&gt;(1);
    ///
    ///     // This will throw because it's not an Error variant causing a test to fail.
    ///     okValue.AssertTrue_WhenError(m => m == "an error message");
    /// </code>
    /// </example>
    /// </summary>
    /// <typeparam name="Ok">The Ok type.</typeparam>
    /// <typeparam name="Error">The Error type.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="predicate">An expression that should be true for the test to pass.</param>
    /// <param name="because">A message that expresses why the assertion should be true for test output.</param>
    public static void AssertTrue_WhenError<Ok, Error>(this Result<Ok, Error> result, Func<Error, bool> predicate, string? because = null)
    {
        var errorValue = result.UnwrapError();

        predicate(errorValue)
            .Should()
            .BeTrue(because ?? "the predicate was expected to be true");
    }

    /// <summary>
    /// Assert that the result is an Error variant, and that the predicate provided will return false.
    /// <example><br /><br/>
    /// Example:
    /// <code>
    ///     // An Error variant with the inner value "an error message".
    ///     var error = new Result&lt;int, string&gt;("an error message");
    ///     
    ///     // This won't throw because the value doesn't match the predicate and is an Error variant.
    ///     error.AssertFalse_WhenError(m => m == "a different message");
    ///     
    ///     // This will throw an exception because the value equals "an error message" causing the test to fail.
    ///     error.AssertFalse_WhenError(m => m == "an error message");
    ///     
    ///     // This is an Ok variant.
    ///     var okValue = new Result&lt;int, string&gt;(1);
    ///
    ///     // This will throw because it's not an Error variant causing a test to fail.
    ///     okValue.AssertFalse_WhenError(m => m == "a different message");
    /// </code>
    /// </example>
    /// </summary>
    /// <typeparam name="Ok">The Ok type.</typeparam>
    /// <typeparam name="Error">The Error type.</typeparam>
    /// <param name="result">The result to assert.</param>
    /// <param name="predicate">An expression that should be true for the test to pass.</param>
    /// <param name="because">A message that expresses why the assertion should be true for test output.</param>

    public static void AssertFalse_WhenError<Ok, Error>(this Result<Ok, Error> result, Func<Error, bool> predicate, string? because = null)
    {
        var errorValue = result.UnwrapError();

        predicate(errorValue)
            .Should()
            .BeFalse(because ?? "the predicate was expected to be false");
    }
}
