namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AdStart(T[] options) => 0;

    private static int Ad(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (high, low, close, volume) = inputs;
        var output = outputs[0];

        T sum = T.Zero;
        for (var i = 0; i < size; ++i)
        {
            T hl = high[i] - low[i];
            if (!T.IsZero(hl))
            {
                sum += (close[i] - low[i] - high[i] + close[i]) / hl * volume[i];
            }

            output[i] = sum;
        }

        return TI_OKAY;
    }
}
