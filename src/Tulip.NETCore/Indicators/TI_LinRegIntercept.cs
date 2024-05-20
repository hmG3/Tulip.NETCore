namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int LinRegInterceptStart(T[] options) => Int32.CreateTruncating(options[0]) - 1;

    private static int LinRegIntercept(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= LinRegStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T x = T.Zero; // Sum of Xs.
        T x2 = T.Zero; // Sum of square of Xs.
        T y = T.Zero; // Flat sum of previous numbers.
        T xy = T.Zero; // Weighted sum of previous numbers.
        for (var i = 0; i < period - 1; ++i)
        {
            x += T.CreateChecked(i + 1);
            x2 += T.CreateChecked((i + 1) * (i + 1));
            xy += input[i] * T.CreateChecked(i + 1);
            y += input[i];
        }

        x += T.CreateChecked(period);
        x2 += T.CreateChecked(period * period);

        T p = T.One / T.CreateChecked(period);
        T bd = T.One / (T.CreateChecked(period) * x2 - x * x);
        int outputIndex = default;
        for (var i = period - 1; i < size; ++i)
        {
            xy += input[i] * T.CreateChecked(period);
            y += input[i];
            T b = (T.CreateChecked(period) * xy - x * y) * bd;
            T a = (y - b * x) * p;
            output[outputIndex++] = a + b;
            xy -= y;
            y -= input[i - period + 1];
        }

        return TI_OKAY;
    }
}
