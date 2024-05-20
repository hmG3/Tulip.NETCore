namespace Tulip;

internal static partial class Tinet<T> where T : IFloatingPointIeee754<T>
{
    private static int RsiStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Rsi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= RsiStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T smoothUp = T.Zero;
        T smoothDown = T.Zero;
        for (var i = 1; i <= period; ++i)
        {
            T upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : T.Zero;
            T downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : T.Zero;
            smoothUp += upward;
            smoothDown += downward;
        }

        smoothUp /= T.CreateChecked(period);
        smoothDown /= T.CreateChecked(period);

        T per = T.One / T.CreateChecked(period);
        int outputIndex = default;
        output[outputIndex++] = THundred * (smoothUp / (smoothUp + smoothDown));
        for (var i = period + 1; i < size; ++i)
        {
            T upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : T.Zero;
            T downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : T.Zero;
            smoothUp = (upward - smoothUp) * per + smoothUp;
            smoothDown = (downward - smoothDown) * per + smoothDown;
            output[outputIndex++] = THundred * (smoothUp / (smoothUp + smoothDown));
        }

        return TI_OKAY;
    }
}
