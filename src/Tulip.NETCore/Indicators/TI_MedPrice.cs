namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int MedPriceStart(T[] options) => 0;

    private static int MedPrice(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var (high, low) = inputs;
        var output = outputs[0];

        for (var i = 0; i < size; ++i)
        {
            output[i] = (high[i] + low[i]) * T.CreateChecked(0.5);
        }

        return TI_OKAY;
    }
}
