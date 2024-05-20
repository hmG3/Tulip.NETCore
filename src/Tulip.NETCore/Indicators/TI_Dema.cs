namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int DemaStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) * 2;

    private static int Dema(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= DemaStart(options))
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
        T ema2 = ema;
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
                if (i >= (period - 1) * 2)
                {
                    output[outputIndex++] = ema * TTwo - ema2;
                }
            }
        }

        return TI_OKAY;
    }
}
