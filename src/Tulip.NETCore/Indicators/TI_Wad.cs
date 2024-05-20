namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int WadStart(T[] options) => 1;

    private static int Wad(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= WadStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, close) = inputs;
        var output = outputs[0];

        T sum = T.Zero;
        T yc = close[0];
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            T c = close[i];
            if (c > yc)
            {
                sum += c - T.Min(yc, low[i]);
            }
            else if (c < yc)
            {
                sum += c - T.Max(yc, high[i]);
            }

            output[outputIndex++] = sum;
            yc = close[i];
        }

        return TI_OKAY;
    }
}
