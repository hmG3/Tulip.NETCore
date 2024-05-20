namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int PviStart(T[] options) => 0;

    private static int Pvi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= PviStart(options))
        {
            return TI_OKAY;
        }

        var (close, volume) = inputs;
        var output = outputs[0];

        T pvi = T.CreateChecked(1000);
        int outputIndex = default;
        output[outputIndex++] = pvi;
        for (var i = 1; i < size; ++i)
        {
            if (volume[i] > volume[i - 1])
            {
                pvi += (close[i] - close[i - 1]) / close[i - 1] * pvi;
            }

            output[outputIndex++] = pvi;
        }

        return TI_OKAY;
    }
}
