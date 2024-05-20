namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int CciStart(T[] options) => (Int32.CreateTruncating(options[0]) - 1) * 2;

    private static int Cci(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= CciStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        T scale = T.One / T.CreateChecked(period);
        var sum = BufferFactory(period);
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            T today = (high[i] + low[i] + close[i]) * (T.One / TThree);
            BufferPush(ref sum, today);

            T avg = sum.sum * scale;
            if (i >= period * 2 - 2)
            {
                T acc = T.Zero;
                for (var j = 0; j < period; ++j)
                {
                    acc += T.Abs(avg - sum.vals[j]);
                }

                T cci = acc * scale * T.CreateChecked(0.015);
                cci = (today - avg) / cci;
                output[outputIndex++] = cci;
            }
        }

        return TI_OKAY;
    }
}
