namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int VhfStart(T[] options) => Int32.CreateTruncating(options[0]);

    private static int Vhf(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 1)
        {
            return TI_INVALID_OPTION;
        }

        if (size <= VhfStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        T sum = T.Zero;
        T yc = input[0];
        for (var i = 1; i < period; ++i)
        {
            T c = input[i];
            sum += T.Abs(c - yc);
            yc = c;
        }

        var maxi = -1;
        var mini = -1;
        T max = input[0];
        T min = input[0];
        int outputIndex = default;
        for (int i = period, trail = 1; i < size; ++i, ++trail)
        {
            T c = input[i];
            sum += T.Abs(c - yc);
            yc = c;
            if (i > period)
            {
                sum -= T.Abs(input[i - period] - input[i - period - 1]);
            }

            // Maintain highest.
            T bar = c;
            if (maxi < trail)
            {
                maxi = trail;
                max = input[maxi];
                int j = trail;
                while (++j <= i)
                {
                    bar = input[j];
                    if (bar >= max)
                    {
                        max = bar;
                        maxi = j;
                    }
                }
            }
            else if (bar >= max)
            {
                maxi = i;
                max = bar;
            }

            // Maintain lowest.
            bar = c;
            if (mini < trail)
            {
                mini = trail;
                min = input[mini];
                int j = trail;
                while (++j <= i)
                {
                    bar = input[j];
                    if (bar <= min)
                    {
                        min = bar;
                        mini = j;
                    }
                }
            }
            else if (bar <= min)
            {
                mini = i;
                min = bar;
            }

            // Calculate it.
            output[outputIndex++] = T.Abs(max - min) / sum;
        }

        return TI_OKAY;
    }
}
