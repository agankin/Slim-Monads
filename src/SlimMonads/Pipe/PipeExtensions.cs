namespace SlimMonads;

public static class PipeExtensions
{
    /// <summary>
    /// Tranforms a value by applying a function.
    /// </summary>
    /// <typeparam name="TValue">Value type.</typeparam>
    /// <typeparam name="TResult">Result type.</typeparam>
    /// <param name="value">A value.</param>
    /// <param name="transform">A transforming function.</param>
    /// <returns>The result of the value transformation.</returns>
    public static TResult Pipe<TValue, TResult>(this TValue value, Func<TValue, TResult> transform) => transform(value);

    /// <summary>
    /// Tranforms a value by applying an async function.
    /// </summary>
    /// <typeparam name="TValue">Value type.</typeparam>
    /// <typeparam name="TResult">Result type.</typeparam>
    /// <param name="value">A value.</param>
    /// <param name="transform">A transforming function.</param>
    /// <returns>A task representing the result of the value transformation.</returns>
    public static async Task<TResult> PipeAsync<TValue, TResult>(this TValue value, Func<TValue, Task<TResult>> transformAsync)
    {
        var result = await transformAsync(value);
        return result;
    }

    /// <summary>
    /// Awaits for the value task and tranforms the value by applying an async function.
    /// </summary>
    /// <typeparam name="TValue">Value type.</typeparam>
    /// <typeparam name="TResult">Result type.</typeparam>
    /// <param name="valueTask">A value task.</param>
    /// <param name="transform">A transforming function.</param>
    /// <returns>A task representing the result of the value transformation.</returns>
    public static async Task<TResult> PipeAsync<TValue, TResult>(this Task<TValue> valueTask, Func<TValue, Task<TResult>> transformAsync)
    {
        var value = await valueTask;
        var result = await transformAsync(value);
        
        return result;
    }
}