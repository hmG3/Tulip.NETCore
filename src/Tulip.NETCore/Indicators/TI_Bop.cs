namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int BopStart(T[] options) => 0;

    private static int Bop(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (open, high, low, close) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            T hl = high[i] - low[i];
            output[i] = hl > T.Zero ? (close[i] - open[i]) / hl : T.Zero;
        }

        return TI_OKAY;
    }
}
