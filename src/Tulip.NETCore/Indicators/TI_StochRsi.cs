namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private static int StochRsiStart(T[] options) => Int32.CreateTruncating(options[0]) * 2 - 1;

    private static int StochRsi(int size, T[][] inputs, T[] options, T[][] outputs)
    {
        var period = Int32.CreateTruncating(options[0]);

        if (period < 2)
        {
            // if period = 0 then min-max = 0.
            return TI_INVALID_OPTION;
        }

        if (size <= StochRsiStart(options))
        {
            return TI_OKAY;
        }

        var input = inputs[0];
        var output = outputs[0];

        var rsi = BufferFactory(period);

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

        T r = THundred * (smoothUp / (smoothUp + smoothDown));
        BufferPush(ref rsi, r);

        T per = T.One / T.CreateChecked(period);
        T min = r;
        T max = r;
        int mini = default;
        int maxi = default;
        int outputIndex = default;
        for (var i = period + 1; i < size; ++i)
        {
            T upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : T.Zero;
            T downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : T.Zero;

            smoothUp = (upward - smoothUp) * per + smoothUp;
            smoothDown = (downward - smoothDown) * per + smoothDown;

            r = THundred * (smoothUp / (smoothUp + smoothDown));

            if (r > max)
            {
                max = r;
                maxi = rsi.index;
            }
            else if (maxi == rsi.index)
            {
                max = r;
                for (var j = 0; j < rsi.size; ++j)
                {
                    if (j == rsi.index)
                    {
                        continue;
                    }

                    if (rsi.vals[j] > max)
                    {
                        max = rsi.vals[j];
                        maxi = j;
                    }
                }
            }

            if (r < min)
            {
                min = r;
                mini = rsi.index;
            }
            else if (mini == rsi.index)
            {
                min = r;
                for (var j = 0; j < rsi.size; ++j)
                {
                    if (j == rsi.index)
                    {
                        continue;
                    }

                    if (rsi.vals[j] < min)
                    {
                        min = rsi.vals[j];
                        mini = j;
                    }
                }
            }

            BufferQPush(ref rsi, r);

            if (i > period * 2 - 2)
            {
                T diff = max - min;
                output[outputIndex++] = T.IsZero(diff) ? T.Zero : (r - min) / diff;
            }
        }

        return TI_OKAY;
    }
}
