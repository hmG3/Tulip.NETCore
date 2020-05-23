using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int StochRsiStart(double[] options) => (int) options[0] * 2 - 1;

        private static int StochRsiStart(decimal[] options) => (int) options[0] * 2 - 1;

        private static int StochRsi(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

            if (period < 2)
            {
                // if period = 0 then min-max = 0.
                return TI_INVALID_OPTION;
            }

            if (size <= StochRsiStart(options))
            {
                return TI_OKAY;
            }

            double[] input = inputs[0];
            double[] output = outputs[0];

            var rsi = BufferDoubleFactory(period);

            double smoothUp = default;
            double smoothDown = default;
            for (var i = 1; i <= period; ++i)
            {
                double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0;
                double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0;
                smoothUp += upward;
                smoothDown += downward;
            }

            smoothUp /= period;
            smoothDown /= period;

            double r = 100.0 * (smoothUp / (smoothUp + smoothDown));
            BufferPush(ref rsi, r);

            double per = 1.0 / period;
            double min = r;
            double max = r;
            int mini = default;
            int maxi = default;
            int outputIndex = default;
            for (var i = period + 1; i < size; ++i)
            {
                double upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0;
                double downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0;

                smoothUp = (upward - smoothUp) * per + smoothUp;
                smoothDown = (downward - smoothDown) * per + smoothDown;

                r = 100.0 * (smoothUp / (smoothUp + smoothDown));

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
                    double diff = max - min;
                    output[outputIndex++] = diff.Equals(0.0) ? 0.0 : (r - min) / diff;
                }
            }

            return TI_OKAY;
        }

        private static int StochRsi(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

            if (period < 2)
            {
                // if period = 0 then min-max = 0.
                return TI_INVALID_OPTION;
            }

            if (size <= StochRsiStart(options))
            {
                return TI_OKAY;
            }

            decimal[] input = inputs[0];
            decimal[] output = outputs[0];

            var rsi = BufferDecimalFactory(period);

            decimal smoothUp = default;
            decimal smoothDown = default;
            for (var i = 1; i <= period; ++i)
            {
                decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0;
                decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0;
                smoothUp += upward;
                smoothDown += downward;
            }

            smoothUp /= period;
            smoothDown /= period;

            decimal r = 100m * (smoothUp / (smoothUp + smoothDown));
            BufferPush(ref rsi, r);

            decimal per = Decimal.One / period;
            decimal min = r;
            decimal max = r;
            int mini = default;
            int maxi = default;
            int outputIndex = default;
            for (var i = period + 1; i < size; ++i)
            {
                decimal upward = input[i] > input[i - 1] ? input[i] - input[i - 1] : 0;
                decimal downward = input[i] < input[i - 1] ? input[i - 1] - input[i] : 0;

                smoothUp = (upward - smoothUp) * per + smoothUp;
                smoothDown = (downward - smoothDown) * per + smoothDown;

                r = 100m * (smoothUp / (smoothUp + smoothDown));

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
                    decimal diff = max - min;
                    output[outputIndex++] = diff == Decimal.Zero ? Decimal.Zero : (r - min) / diff;
                }
            }

            return TI_OKAY;
        }
    }
}
