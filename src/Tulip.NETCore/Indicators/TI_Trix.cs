namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TrixStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) * 3 + 1;

    private static int Trix(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= TrixStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        int start = period * 3 - 2;
        T per = TTwo / T.CreateChecked(period + 1);
        T ema1 = input[0];
        T ema2 = T.Zero;
        T ema3 = T.Zero;
        for (var i = 1; i < start; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            if (i == period - 1)
            {
                ema2 = ema1;
            }
            else if (i > period - 1)
            {
                ema2 = (ema1 - ema2) * per + ema2;
                if (i == period * 2 - 2)
                {
                    ema3 = ema2;
                }
                else if (i > period * 2 - 2)
                {
                    ema3 = (ema2 - ema3) * per + ema3;
                }
            }
        }

        int outputIndex = default;
        for (int i = start; i < size; ++i)
        {
            ema1 = (input[i] - ema1) * per + ema1;
            ema2 = (ema1 - ema2) * per + ema2;
            T last = ema3;
            ema3 = (ema2 - ema3) * per + ema3;
            output[outputIndex++] = (ema3 - last) / ema3 * THundred;
        }

        return TI_OKAY;
    }
}
