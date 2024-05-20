namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int CviStart(T[] options) => Int32.CreateTruncating(options[0]) * 2 - 1;

    private static int Cvi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= CviStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        T per = TTwo / T.CreateChecked(period + 1);
        var lag = BufferFactory(period);
        T val = high[0] - low[0];
        for (var i = 1; i < period * 2 - 1; ++i)
        {
            val = (high[i] - low[i] - val) * per + val;
            BufferQPush(ref lag, val);
        }

        int outputIndex = default;
        for (var i = period * 2 - 1; i < size; ++i)
        {
            val = (high[i] - low[i] - val) * per + val;
            T old = lag.vals[lag.index];
            output[outputIndex++] = THundred * (val - old) / old;
            BufferQPush(ref lag, val);
        }

        return TI_OKAY;
    }
}
