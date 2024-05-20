namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int KamaStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Kama(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= KamaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        for (var i = 1; i < period; ++i)
        {
            sum += T.Abs(input[i] - input[i - 1]);
        }

        // The caller selects the period used in the efficiency ratio. The fast and slow periods are hard set by the algorithm.
        T shortPer = TTwo / T.CreateChecked(2 + 1);
        T longPer = TTwo / T.CreateChecked(30 + 1);

        T kama = input[period - 1];
        int outputIndex = default;
        output[outputIndex++] = kama;
        for (var i = period; i < size; ++i)
        {
            sum += T.Abs(input[i] - input[i - 1]);
            if (i > period)
            {
                sum -= T.Abs(input[i - period] - input[i - period - 1]);
            }

            T er = !T.IsZero(sum) ? T.Abs(input[i] - input[i - period]) / sum : T.One;
            T sc = T.Pow(er * (shortPer - longPer) + longPer, TTwo);

            kama += sc * (input[i] - kama);
            output[outputIndex++] = kama;
        }

        return TI_OKAY;
    }
}
