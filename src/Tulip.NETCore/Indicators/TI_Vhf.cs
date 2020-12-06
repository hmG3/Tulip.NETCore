using System;

namespace Tulip
{
    internal static partial class Tinet
    {
        private static int VhfStart(double[] options) => (int) options[0];

        private static int VhfStart(decimal[] options) => (int) options[0];

        private static int Vhf(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            var period = (int) options[0];

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

            double sum = default;
            double yc = input[0];
            for (var i = 1; i < period; ++i)
            {
                double c = input[i];
                sum += Math.Abs(c - yc);
                yc = c;
            }

            var maxi = -1;
            var mini = -1;
            double max = input[0];
            double min = input[0];
            int outputIndex = default;
            for (int i = period, trail = 1; i < size; ++i, ++trail)
            {
                double c = input[i];
                sum += Math.Abs(c - yc);
                yc = c;
                if (i > period)
                {
                    sum -= Math.Abs(input[i - period] - input[i - period - 1]);
                }

                // Maintain highest.
                double bar = c;
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
                output[outputIndex++] = Math.Abs(max - min) / sum;
            }

            return TI_OKAY;
        }

        private static int Vhf(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            var period = (int) options[0];

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

            decimal sum = default;
            decimal yc = input[0];
            for (var i = 1; i < period; ++i)
            {
                decimal c = input[i];
                sum += Math.Abs(c - yc);
                yc = c;
            }

            var maxi = -1;
            var mini = -1;
            decimal max = input[0];
            decimal min = input[0];
            int outputIndex = default;
            for (int i = period, trail = 1; i < size; ++i, ++trail)
            {
                decimal c = input[i];
                sum += Math.Abs(c - yc);
                yc = c;
                if (i > period)
                {
                    sum -= Math.Abs(input[i - period] - input[i - period - 1]);
                }

                // Maintain highest.
                decimal bar = c;
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
                output[outputIndex++] = Math.Abs(max - min) / sum;
            }

            return TI_OKAY;
        }
    }
}
