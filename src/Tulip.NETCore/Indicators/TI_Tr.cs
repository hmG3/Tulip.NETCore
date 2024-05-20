namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int TrStart(T[] options) => 0;

    private static int Tr(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (high, low, close) = inputs;
        var output = outputs[0];

        output[0] = high[0] - low[0];
        for (var i = 1; i < size; ++i)
        {
            CalcTrueRange(low, high, close, i, out T trueRange);
            output[i] = trueRange;
        }

        return TI_OKAY;
    }
}
