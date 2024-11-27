
using FluentAssertions;

namespace Functional.Testing;
public static partial class Prelude
{
    /// <summary>
    /// Assert that the predicate is true.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="value">The value to assert.</param>
    /// <param name="predicate">A predicate function.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static T AssertTrue<T>(this T value, Func<T, bool> predicate, string? because = null)
    {
        predicate(value)
            .Should()
            .BeTrue(because ?? "the predicate was expected to be true");

        return value;
    }

    /// <summary>
    /// Assert that the predicate is true.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="value">The value to assert.</param>
    /// <param name="predicate">A predicate function.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static async Task<T> AssertTrueAsync<T>(this Task<T> value, Func<T, bool> predicate, string? because = null) =>
        await value.PipeAsync(v => v.AssertTrue(predicate, because));

    /// <summary>
    /// Assert that the value is true.
    /// </summary>
    /// <param name="value">The value to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static bool AssertTrue(this bool value, string? because = null)
    {
        value
            .Should()
            .BeTrue(because ?? "the value was expected to be true");

        return value;
    }

    /// <summary>
    /// Assert that the value is true.
    /// </summary>
    /// <param name="value">The value to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static async Task<bool> AssertTrueAsync(this Task<bool> value, string? because = null) =>
        await value.PipeAsync(v => v.AssertTrue(because));

    /// <summary>
    /// Assert that the predicate is false.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="value">The value to assert.</param>
    /// <param name="predicate">A predicate function.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static T AssertFalse<T>(this T value, Func<T, bool> predicate, string? because = null)
    {
        predicate(value)
            .Should()
            .BeFalse(because ?? "the predicate was expected to be false");

        return value;
    }

    /// <summary>
    /// Assert that the predicate is false.
    /// </summary>
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="value">The value to assert.</param>
    /// <param name="predicate">A predicate function.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static async Task<T> AssertFalseAsync<T>(this Task<T> value, Func<T, bool> predicate, string? because = null) =>
        await value.PipeAsync(v => v.AssertFalse(predicate, because));

    /// <summary>
    /// Assert that the value is false.
    /// </summary>
    /// <param name="value">The value to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static bool AssertFalse(this bool value, string? because = null)
    {
        value
            .Should()
            .BeFalse(because ?? "the value was expected to be false");

        return value;
    }

    /// <summary>
    /// Assert that the value is false.
    /// </summary>
    /// <param name="value">The value to assert.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    public static async Task<bool> AssertFalseAsync(this Task<bool> value, string? because = null) =>
        await value.PipeAsync(v => v.AssertFalse(because));

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertEqual<T>(this T value, T expected, string? because = null) =>
        value
            .Tap(v =>
                v.Should()
                .Be(expected, because ?? "the two values were expected to be equal"));

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertEqualAsync<T>(this Task<T> value, T expected, string? because = null) =>
        await value.PipeAsync(v => v.AssertEqual(expected, because));

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertEqual<T, U>(this T value, Func<T, U> selector, U expected, string? because = null)
    {
        var selected = selector(value);
        selected.Should().Be(expected, because ?? "the two values were expected to be equal");
        return value;
    }

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertEqualAsync<T, U>(this Task<T> value, Func<T, U> selector, U expected, string? because = null)
    {
        var awaited = await value;
        return awaited.AssertEqual(selector, expected, because);
    }

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertNotEqual<T>(this T value, T expected, string? because = null) =>
        value
            .Tap(v =>
                v.Should()
                    .NotBe(expected, because ?? "the two values were expected to not be equal"));

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <typeparam name="U">The type of the property to compare.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertNotEqual<T, U>(this T value, Func<T, U> selector, U expected, string? because = null)
    {
        var selected = selector(value);
        selected.Should().NotBe(expected, because ?? "the two values were expected to not be equal");
        return value;
    }

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertNotEqualAsync<T>(this Task<T> value, T expected, string? because = null) =>
        await value.PipeAsync(v => v.AssertNotEqual(expected, because));

    /// <summary>
    /// Compares two values by using the Object.Equals method. By default this compares objects
    /// by reference unless the Equals method has been overridden for the input type.
    /// </summary>
    /// <typeparam name="T">The input type.</typeparam>
    /// <typeparam name="U">The type of the property to compare.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The value of the object to compare to.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertNotEqualAsync<T, U>(this Task<T> value, Func<T, U> selector, U expected, string? because = null)
    {
        var awaited = await value;
        return awaited.AssertNotEqual(selector, expected, because);
    }

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The expected value.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertEquivalent<T>(this T value, T expected, string? because = null) =>
        value
            .Tap(v =>
                v.Should()
                .BeEquivalentTo(expected, because ?? "the two values were expected to be equivalent"));

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="U">The type of the selected property.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertEquivalent<T, U>(this T value, Func<T, U> selector, U expected, string? because = null)
    {
        var selected = selector(value);
        selected.Should().BeEquivalentTo(expected, because ?? "the two values were expected to be equivalent");
        return value;
    }

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The expected value.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertEquivalentAsync<T>(this Task<T> value, T expected, string? because = null) =>
        await value.PipeAsync(v => v.AssertEquivalent(expected, because));

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="U">The type of the selected property.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertEquivalentAsync<T, U>(this Task<T> value, Func<T, U> selector, U expected, string? because = null)
    {
        var awaited = await value;
        return awaited.AssertEquivalent(selector, expected, because);
    }

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The expected value.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertNotEquivalent<T>(this T value, T expected, string? because = null) =>
        value
            .Tap(v =>
                v.Should()
                .NotBeEquivalentTo(expected, because ?? "the two values were expected to not be equivalent"));

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="U">The type of the selected property.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static T AssertNotEquivalent<T, U>(this T value, Func<T, U> selector, U expected, string? because = null)
    {
        var selected = selector(value);
        selected.Should().NotBeEquivalentTo(expected, because ?? "the two values were expected to not be equivalent");
        return value;
    }

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="expected">The expected value.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertNotEquivalentAsync<T>(this Task<T> value, T expected, string? because = null) =>
        await value.PipeAsync(v => v.AssertNotEquivalent(expected, because));

    /// <summary>
    /// Compares two values by structural equality. For collections, as long as both types implement
    /// IEnumerable, they will be considered equivalent if all of their contained values are also structurally equivalent.
    /// </summary>
    /// <typeparam name="T">The type of the input.</typeparam>
    /// <typeparam name="U">The type of the selected property.</typeparam>
    /// <param name="value">The input value.</param>
    /// <param name="selector">A property selector.</param>
    /// <param name="expected">The expected value.</param>
    /// <param name="because">A testing message that indicates why the assertion is expected.</param>
    /// <returns>The input value for method chaining.</returns>
    public static async Task<T> AssertNotEquivalentAsync<T, U>(this Task<T> value, Func<T, U> selector, U expected, string? because = null)
    {
        var awaited = await value;
        return awaited.AssertNotEquivalent(selector, expected, because);
    }
}
