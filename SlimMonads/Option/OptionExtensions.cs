﻿namespace Memtest
{
    public static class OptionExtensions
    {
        /// <summary>
        /// Wraps the value into Some option.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="value">A value.</param>
        /// <returns>The original value wrapped into Some option.</returns>
        public static Option<TValue> Some<TValue>(this TValue value) => value;

        /// <summary>
        /// If the value is not null then wraps it into Some option otherwise returns None.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <param name="value">A value.</param>
        /// <returns>The original value wrapped into Some option or None.</returns>
        public static Option<TValue> NullToNone<TValue>(this TValue? value) =>
            value?.Some() ?? Option<TValue>.None();

        /// <summary>
        /// Returns the original option if it is Some or <paramref name="alternativeValue"/> wrapped into Some option.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <typeparam name="TOption">Option type.</typeparam>
        /// <param name="option">An option.</param>
        /// <param name="alternativeValue">An alternative value.</param>
        /// <returns>Original Some option or <paramref name="alternativeValue"/> wrapped into Some option.</returns>
        public static TValue Or<TValue, TOption>(this TOption option, TValue alternativeValue)
            where TOption : IOption<TValue>
        {
            return option.Match(value => value, () => alternativeValue);
        }

        /// <summary>
        /// Returns the original option if it is Some or a value from <paramref name="getAlternativeValue"/>
        /// invocation wrapped into Some option.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <typeparam name="TOption">Option type.</typeparam>
        /// <param name="option">An option.</param>
        /// <param name="getAlternativeValue">An alternative value factory.</param>
        /// <returns>
        /// The original option or wrapped into Some option value from <paramref name="getAlternativeValue"/> invocation.
        /// </returns>
        public static TValue Or<TValue, TOption>(this TOption option, Func<TValue> getAlternativeValue)
            where TOption : IOption<TValue>
        {
            return option.Match(value => value, getAlternativeValue);
        }

        /// <summary>
        /// Returns the original option if it is Some or <paramref name="alternativeOption"/>.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <typeparam name="TOption">Option type.</typeparam>
        /// <param name="option">An option.</param>
        /// <param name="alternativeOption">An alternative option.</param>
        /// <returns>Original option or <paramref name="alternativeOption"/>.</returns>
        public static Option<TValue> Or<TValue, TOption>(this TOption option, Option<TValue> alternativeOption)
            where TOption : IOption<TValue>
        {
            return option.Match(value => value, () => alternativeOption);
        }

        /// <summary>
        /// Returns the original option if it is Some or a value from <paramref name="getAlternativeOption"/> invocation.
        /// </summary>
        /// <typeparam name="TValue">Value type.</typeparam>
        /// <typeparam name="TOption">Option type.</typeparam>
        /// <param name="option">An option.</param>
        /// <param name="alternativeOption">An alternative option factory.</param>
        /// <returns>
        /// Original option or a value from <paramref name="getAlternativeOption"/> invocation.
        /// </returns>
        public static Option<TValue> Or<TValue, TOption>(this TOption option, Func<Option<TValue>> getAlternativeOption)
            where TOption : IOption<TValue>
        {
            return option.Match(value => value, getAlternativeOption);
        }
    }
}