namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TemaStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) * 3;

    private static int Tema(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= TemaStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T per = TTwo / T.CreateChecked(period + 1);
        T per1 = T.One - per;
        // Calculate EMA(input)
        T ema = input[0];

        // Calculate EMA(EMA(input))
        T ema2 = T.Zero;

        // Calculate EMA(EMA(EMA(input)))
        T ema3 = T.Zero;
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            ema = ema * per1 + input[i] * per;
            if (i == period - 1)
            {
                ema2 = ema;
            }

            if (i >= period - 1)
            {
                ema2 = ema2 * per1 + ema * per;
                if (i == (period - 1) * 2)
                {
                    ema3 = ema2;
                }

                if (i >= (period - 1) * 2)
                {
                    ema3 = ema3 * per1 + ema2 * per;
                    if (i >= (period - 1) * 3)
                    {
                        output[outputIndex++] = TThree * ema - TThree * ema2 + ema3;
                    }
                }
            }
        }

        return TI_OKAY;
    }
}
