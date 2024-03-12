using System.Reflection;

namespace Tulip
{
    internal static partial class Tinet
    {
        private const int TI_OKAY = 0;
        private const int TI_INVALID_OPTION = 1;

        private static (int size, int pushes, int index, double sum, double[] vals) BufferDoubleFactory(int size) =>
            (size, 0, 0, 0.0, new double[size]);

        private static (int size, int pushes, int index, decimal sum, decimal[] vals) BufferDecimalFactory(int size) =>
            (size, 0, 0, Decimal.Zero, new decimal[size]);

        private static void BufferPush(ref (int size, int pushes, int index, double sum, double[] vals) buffer, double val)
        {
            if (buffer.pushes >= buffer.size)
            {
                buffer.sum -= buffer.vals[buffer.index];
            }

            buffer.sum += val;
            buffer.vals[buffer.index++] = val;
            ++buffer.pushes;
            if (buffer.index >= buffer.size)
            {
                buffer.index = 0;
            }
        }

        private static void BufferPush(ref (int size, int pushes, int index, decimal sum, decimal[] vals) buffer, decimal val)
        {
            if (buffer.pushes >= buffer.size)
            {
                buffer.sum -= buffer.vals[buffer.index];
            }

            buffer.sum += val;
            buffer.vals[buffer.index++] = val;
            ++buffer.pushes;
            if (buffer.index >= buffer.size)
            {
                buffer.index = 0;
            }
        }

        private static void BufferQPush(ref (int size, int pushes, int index, double sum, double[] vals) buffer, double val)
        {
            buffer.vals[buffer.index++] = val;
            if (buffer.index >= buffer.size)
            {
                buffer.index = 0;
            }
        }

        private static void BufferQPush(ref (int size, int pushes, int index, decimal sum, decimal[] vals) buffer, decimal val)
        {
            buffer.vals[buffer.index++] = val;
            if (buffer.index >= buffer.size)
            {
                buffer.index = 0;
            }
        }

        private static double BufferGet((int, int, int, double, double[]) buffer, double val)
        {
            var (size, _, index, _, vals) = buffer;
            return vals[(Index) ((index + size - 1 + val) % size)];
        }

        private static decimal BufferGet((int, int, int, decimal, decimal[]) buffer, decimal val)
        {
            var (size, _, index, _, vals) = buffer;
            return vals[(Index) ((index + size - 1 + val) % size)];
        }

        private static void CalcTrueRange(double[] low, double[] high, double[] close, int i, out double trueRange)
        {
            double l = low[i];
            double h = high[i];
            double c = close[i - 1];
            double ych = Math.Abs(h - c);
            double ycl = Math.Abs(l - c);
            double v = h - l;
            if (ych > v)
            {
                v = ych;
            }

            if (ycl > v)
            {
                v = ycl;
            }

            trueRange = v;
        }

        private static void CalcTrueRange(decimal[] low, decimal[] high, decimal[] close, int i, out decimal trueRange)
        {
            decimal l = low[i];
            decimal h = high[i];
            decimal c = close[i - 1];
            decimal ych = Math.Abs(h - c);
            decimal ycl = Math.Abs(l - c);
            decimal v = h - l;
            if (ych > v)
            {
                v = ych;
            }

            if (ycl > v)
            {
                v = ycl;
            }

            trueRange = v;
        }

        private static void CalcDirection(double[] high, double[] low, int i, out double up, out double down)
        {
            up = high[i] - high[i - 1];
            down = low[i - 1] - low[i];

            if (up < 0.0)
            {
                up = 0.0;
            }
            else if (up > down)
            {
                down = 0.0;
            }

            if (down < 0.0)
            {
                down = 0.0;
            }
            else if (down > up)
            {
                up = 0.0;
            }
        }

        private static void CalcDirection(decimal[] high, decimal[] low, int i, out decimal up, out decimal down)
        {
            up = high[i] - high[i - 1];
            down = low[i - 1] - low[i];

            if (up < Decimal.Zero)
            {
                up = Decimal.Zero;
            }
            else if (up > down)
            {
                down = Decimal.Zero;
            }

            if (down < Decimal.Zero)
            {
                down = Decimal.Zero;
            }
            else if (down > up)
            {
                up = Decimal.Zero;
            }
        }

        private static void Simple1<T>(int size, T[] input, T[] output, Func<T, T> op) where T : IComparable<T>
        {
            for (var i = 0; i < size; ++i)
            {
                output[i] = op(input[i]);
            }
        }

        private static void Simple2<T>(int size, T[] input1, T[] input2, T[] output, Func<T, T, T> op) where T : IComparable<T>
        {
            for (var i = 0; i < size; ++i)
            {
                output[i] = op(input1[i], input2[i]);
            }
        }

        public static int IndicatorRun<T>(string name, T[][] inputs, T[] options, T[][] outputs) where T : IComparable<T>
        {
            try
            {
                typeof(Tinet).InvokeMember(name, BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                    Type.DefaultBinder, null, new object[] { inputs[0].Length, inputs, options, outputs });

            }
            catch (MissingMethodException)
            {
                return TI_INVALID_OPTION;
            }

            return TI_OKAY;
        }

        public static int IndicatorStart<T>(string name, T[] options) where T : IComparable<T>
        {
            const string lookbackSuffix = "Start";

            try
            {
                return Convert.ToInt32(typeof(Tinet).InvokeMember($"{name}{lookbackSuffix}",
                    BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                    Type.DefaultBinder, null, new object[] { options }));
            }
            catch (MissingMethodException)
            {
                return TI_INVALID_OPTION;
            }
        }
    }
}
