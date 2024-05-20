namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int DecayStart(T[] options) => 0;

    private static int Decay(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var input = inputs[0];
        var output = outputs[0];
        var period = Int32.CreateTruncating(options[0]);

        T scale = T.One / T.CreateChecked(period);
        int outputIndex = default;
        output[outputIndex++] = input[0];
        for (var i = 1; i < size; ++i)
        {
            T d = output[i - 1] - scale;
            output[outputIndex++] = input[i] > d ? input[i] : d;
        }

        return TI_OKAY;
    }
}
