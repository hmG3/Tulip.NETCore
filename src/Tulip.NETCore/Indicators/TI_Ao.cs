namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int AoStart(T[] options) => 33;

    private static int Ao(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        if (size <= AoStart(options))
        {
            return TI_OKAY;
        }

        var (high, low) = inputs;
        var output = outputs[0];

        T sum34 = T.Zero;
        T sum5 = T.Zero;
        for (var i = 0; i < 34; ++i)
        {
            T hl = T.CreateChecked(0.5) * (high[i] + low[i]);
            sum34 += hl;
            if (i >= 29)
            {
                sum5 += hl;
            }
        }

        T per34 = T.One / T.CreateChecked(34);
        T per5 = T.One / T.CreateChecked(5);
        int outputIndex = default;
        output[outputIndex++] = per5 * sum5 - per34 * sum34;
        for (var i = 34; i < size; ++i)
        {
            T hl = T.CreateChecked(0.5) * (high[i] + low[i]);
            sum34 += hl;
            sum5 += hl;

            sum34 -= T.CreateChecked(0.5) * (high[i - 34] + low[i - 34]);
            sum5 -= T.CreateChecked(0.5) * (high[i - 5] + low[i - 5]);
            output[outputIndex++] = per5 * sum5 - per34 * sum34;
        }

        return TI_OKAY;
    }
}
