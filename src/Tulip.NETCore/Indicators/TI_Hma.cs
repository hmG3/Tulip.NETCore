namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int HmaStart(T[] options)
    {
        var period = Int32.CreateTruncating(options[0]);
        return period + Int32.CreateTruncating(T.Sqrt(T.CreateChecked(period))) - 2;
    }

    private static int Hma(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= HmaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        // HMA(input, N) = WMA((2 * WMA(input, N/2) - WMA(input, N)), sqrt(N))
        // Need to do three WMAs, with periods N, N/2, and sqrt N.

        var period2 = period / 2;
        T sum = T.Zero; // Flat sum of previous numbers.
        T weightSum = T.Zero; // Weighted sum of previous numbers.
        T sum2 = T.Zero;
        T weightSum2 = T.Zero;
        // Setup up the WMA(period) and WMA(period/2) on the input.
        for (var i = 0; i < period - 1; ++i)
        {
            weightSum += input[i] * T.CreateChecked(i + 1);
            sum += input[i];
            if (i >= period - period2)
            {
                weightSum2 += input[i] * T.CreateChecked(i + 1 - (period - period2));
                sum2 += input[i];
            }
        }

        var periodSqrt = Int32.CreateTruncating(T.Sqrt(T.CreateChecked(period)));
        T weights = T.CreateChecked(period * (period + 1)) / TTwo;
        T weights2 = T.CreateChecked(period2 * (period2 + 1)) / TTwo;
        T weightsSqrt = T.CreateChecked(periodSqrt * (periodSqrt + 1)) / TTwo;
        T sumSqrt = T.Zero;
        T weightSumSqrt = T.Zero;
        var buff = BufferFactory(periodSqrt);
        int outputIndex = default;
        for (var i = period - 1; i < size; ++i)
        {
            weightSum += input[i] * T.CreateChecked(period);
            sum += input[i];

            weightSum2 += input[i] * T.CreateChecked(period2);
            sum2 += input[i];

            T wma = weightSum / weights;
            T wma2 = weightSum2 / weights2;
            T diff = TTwo * wma2 - wma;

            weightSumSqrt += diff * T.CreateChecked(periodSqrt);
            sumSqrt += diff;
            BufferQPush(ref buff, diff);

            if (i >= period - 1 + (periodSqrt - 1))
            {
                output[outputIndex++] = weightSumSqrt / weightsSqrt;

                weightSumSqrt -= sumSqrt;
                sumSqrt -= BufferGet(buff, 1);
            }
            else
            {
                weightSumSqrt -= sumSqrt;
            }


            weightSum -= sum;
            sum -= input[i - period + 1];

            weightSum2 -= sum2;
            sum2 -= input[i - period2 + 1];
        }

        return TI_OKAY;
    }
}
