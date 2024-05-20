namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MfiStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Mfi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MfiStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close, volume) = inputs;
        var output = outputs[0];

        T yTyp = (high[0] + low[0] + close[0]) * (T.One / TThree);
        var up = BufferFactory(period);
        var down = BufferFactory(period);
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            T typ = (high[i] + low[i] + close[i]) * (T.One / TThree);
            T bar = typ * volume[i];
            if (typ > yTyp)
            {
                BufferPush(ref up, bar);
                BufferPush(ref down, T.Zero);
            }
            else if (typ < yTyp)
            {
                BufferPush(ref down, bar);
                BufferPush(ref up, T.Zero);
            }
            else
            {
                BufferPush(ref up, T.Zero);
                BufferPush(ref down, T.Zero);
            }

            yTyp = typ;
            if (i >= period)
            {
                output[outputIndex++] = up.sum / (up.sum + down.sum) * THundred;
            }
        }

        return TI_OKAY;
    }
}
