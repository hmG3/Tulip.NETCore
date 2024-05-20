namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int CmoStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Cmo(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= CmoStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T upSum = T.Zero;
        T downSum = T.Zero;
        for (var i = 1; i <= period; ++i)
        {
            upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : T.Zero;
            downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : T.Zero;
        }

        int outputIndex = default;
        output[outputIndex++] = THundred * (upSum - downSum) / (upSum + downSum);
        for (var i = period + 1; i < size; ++i)
        {
            upSum -= input[i - period] > input[i - period - 1] ? input[i - period] - input[i - period - 1] : T.Zero;
            downSum -= input[i - period] < input[i - period - 1] ? input[i - period - 1] - input[i - period] : T.Zero;

            upSum += input[i] > input[i - 1] ? input[i] - input[i - 1] : T.Zero;
            downSum += input[i] < input[i - 1] ? input[i - 1] - input[i] : T.Zero;

            output[outputIndex++] = THundred * (upSum - downSum) / (upSum + downSum);
        }

        return TI_OKAY;
    }
}
