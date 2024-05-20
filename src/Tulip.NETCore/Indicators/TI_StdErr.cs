namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int StdErrStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int StdErr(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= StdErrStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        T sum2 = T.Zero;
        for (var i = 0; i < period; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];
        }

        T scale = T.One / T.CreateChecked(period);
        T s2S2 = sum2 * scale - sum * scale * (sum * scale);
        if (s2S2 > T.Zero)
        {
            s2S2 = T.Sqrt(s2S2);
        }

        T mul = T.One / T.Sqrt(T.CreateChecked(period));
        int outputIndex = default;
        output[outputIndex++] = mul * s2S2;
        for (var i = period; i < size; ++i)
        {
            sum += input[i];
            sum2 += input[i] * input[i];

            sum -= input[i - period];
            sum2 -= input[i - period] * input[i - period];
            s2S2 = sum2 * scale - sum * scale * (sum * scale);
            if (s2S2 > T.Zero)
            {
                s2S2 = T.Sqrt(s2S2);
            }

            output[outputIndex++] = mul * s2S2;
        }

        return TI_OKAY;
    }
}
