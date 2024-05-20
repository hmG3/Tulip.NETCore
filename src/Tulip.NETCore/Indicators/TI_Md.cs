namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int MdStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int Md(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= MdStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T scale = T.One / T.CreateChecked(period);
        T sum = T.Zero;
        int outputIndex = default;
        for (var i = 0; i < size; ++i)
        {
            T today = input[i];
            sum += today;
            if (i >= period)
            {
                sum -= input[i - period];
            }

            T avg = sum * scale;
            if (i >= period - 1)
            {
                T acc = T.Zero;
                for (var j = 0; j < period; ++j)
                {
                    acc += T.Abs(avg - input[i - j]);
                }

                output[outputIndex++] = acc * scale;
            }
        }

        return TI_OKAY;
    }
}
