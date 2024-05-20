namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int MarketFiStart(T[] options) => 0;

    private static int MarketFi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= MarketFiStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, volume) = inputs;
        var output = outputs[0];

        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            output[outputIndex++] = (high[i] - low[i]) / volume[i];
        }

        return TI_OKAY;
    }
}
