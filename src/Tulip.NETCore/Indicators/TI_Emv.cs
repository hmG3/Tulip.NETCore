namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int EmvStart(T[] options) => 1;

    private static int Emv(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= EmvStart(options))
        {
            return TI_OKAY;
        }

        var (high, low, volume) = inputs;
        var output = outputs[0];

        T last = (high[0] + low[0]) * T.CreateChecked(0.5);
        int outputIndex = default;
        for (var i = 1; i < size; ++i)
        {
            T hl = (high[i] + low[i]) * T.CreateChecked(0.5);
            T br = volume[i] / T.CreateChecked(10000) / (high[i] - low[i]);
            output[outputIndex++] = (hl - last) / br;
            last = hl;
        }

        return TI_OKAY;
    }
}
