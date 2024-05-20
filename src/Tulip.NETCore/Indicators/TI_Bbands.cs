namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int BbandsStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Bbands(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);
        var stddev = options[1];

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= BbandsStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var (lower, middle, upper) = outputs;

        T sum = T.Zero;
        T sum2 = T.Zero;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];
        }

        T scale = T.One / T.CreateChecked(period);
        T sd = T.Sqrt(sum2 * scale - sum * scale * (sum * scale));

        int lowerIndex = default;
        int middleIndex = default;
        int upperIndex = default;
        middle[middleIndex++] = sum * scale;
        lower[lowerIndex++] = middle[0] - stddev * sd;
        upper[upperIndex++] = middle[0] + stddev * sd;
        for (var i = period; i < size; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];

            sum -= input[i - period];
            sum2 -= input[i - period] * input[i - period];

            sd = T.Sqrt(sum2 * scale - sum * scale * (sum * scale));
            middle[middleIndex] = sum * scale;
            upper[upperIndex++] = middle[middleIndex] + stddev * sd;
            lower[lowerIndex++] = middle[middleIndex] - stddev * sd;
            ++middleIndex;
        }

        return TI_OKAY;
    }
}
