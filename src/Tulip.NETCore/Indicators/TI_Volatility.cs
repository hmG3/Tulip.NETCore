namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VolatilityStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Volatility(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VolatilityStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        T sum2 = T.Zero;
        for (var i = 1; i <= period; ++i)
        {
            T c = input[i] / input[i - 1] - T.One;
            sum += c;
            sum2 += c * c;
        }

        T scale = T.One / T.CreateChecked(period);
        T annual = T.Sqrt(T.CreateChecked(252)); // Multiplier, number of trading days in year.
        int outputIndex = default;
        output[outputIndex++] = T.Sqrt(sum2 * scale - sum * scale * (sum * scale)) * annual;
        for (var i = period + 1; i < size; ++i)
        {
            T c = input[i] / input[i - 1] - T.One;
            sum += c;
            sum2 += c * c;

            T cp = input[i - period] / input[i - period - 1] - T.One;
            sum -= cp;
            sum2 -= cp * cp;

            output[outputIndex++] = T.Sqrt(sum2 * scale - sum * scale * (sum * scale)) * annual;
        }

        return TI_OKAY;
    }
}
