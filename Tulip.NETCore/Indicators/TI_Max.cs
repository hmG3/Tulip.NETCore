namespace Tulip
{
    internal static partial class Tinet
    {
        private static int MaxStart(double[] options)
        {
            return (int) options[0] - 1;
        }

        private static int MaxStart(decimal[] options)
        {
            return (int) options[0] - 1;
        }

        private static int Max(int size, double[][] inputs, double[] options, double[][] outputs)
        {
            double[] input = inputs[0];
            int period = (int) options[0];
            double[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MaxStart(options))
            {
                return TI_OKAY;
            }

            int maxi = -1;
            double max = input[0];
            int outputIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                double bar = input[i];

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

                output[outputIndex++] = max;
            }

            return TI_OKAY;
        }

        private static int Max(int size, decimal[][] inputs, decimal[] options, decimal[][] outputs)
        {
            decimal[] input = inputs[0];
            int period = (int) options[0];
            decimal[] output = outputs[0];

            if (period < 1)
            {
                return TI_INVALID_OPTION;
            }

            if (size <= MaxStart(options))
            {
                return TI_OKAY;
            }

            int maxi = -1;
            decimal max = input[0];
            int outputIndex = default;
            for (int i = period - 1, trail = 0; i < size; ++i, ++trail)
            {
                decimal bar = input[i];

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

                output[outputIndex++] = max;
            }

            return TI_OKAY;
        }
    }
}
