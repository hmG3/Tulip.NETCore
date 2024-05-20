namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int NviStart(T[] options) => 0;

    private static int Nvi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= NviStart(options))
        {
            return TI_OKAY;
        }

        var (close, volume) = inputs;
        var output = outputs[0];

        T nvi = T.CreateChecked(1000);
        int outputIndex = default;
        output[outputIndex++] = nvi;
        for (var i = 1; i < size; ++i)
        {
            if (volume[i] < volume[i - 1])
            {
                nvi += (close[i] - close[i - 1]) / close[i - 1] * nvi;
            }

            output[outputIndex++] = nvi;
        }

        return TI_OKAY;
    }
}
