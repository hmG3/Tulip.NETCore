using System.Reflection;

namespace Tulip;

internal static partial class Tinet<T> where T: IFloatingPointIeee754<T>
{
    private const int TI_OKAY = 0;
    private const int TI_INVALID_OPTION = 1;

    const string LookbackSuffix = "Start";

    private static T TTwo = T.CreateChecked(2);
    private static T TThree = T.CreateChecked(3);
    private static T THundred = T.CreateChecked(100);

    public static int IndicatorRun(string name, T[][] inputs, T[] options, T[][] outputs)
    {
        try
        {
            typeof(Tinet<>).MakeGenericType(typeof(T)).InvokeMember(name,
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                Type.DefaultBinder, null, [inputs[0].Length, inputs, options, outputs]);
        }
        catch (MissingMethodException)
        {
            return TI_INVALID_OPTION;
        }

        return TI_OKAY;
    }

    public static int IndicatorStart(string name, T[] options)
    {
        try
        {
            return Convert.ToInt32(typeof(Tinet<>).MakeGenericType(typeof(T)).InvokeMember($"{name}{LookbackSuffix}",
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.InvokeMethod,
                Type.DefaultBinder, null, [options]));
        }
        catch (MissingMethodException)
        {
            return TI_INVALID_OPTION;
        }
    }

    private static (int size, int pushes, int index, T sum, T[] vals) BufferFactory(int size) =>
        (size, 0, 0, T.Zero, new T[size]);

    private static void BufferPush(ref (int size, int pushes, int index, T sum, T[] vals) buffer, T val)
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

    private static void BufferQPush(ref (int size, int pushes, int index, T sum, T[] vals) buffer, T val)
    {
        buffer.vals[buffer.index++] = val;
        if (buffer.index >= buffer.size)
        {
            buffer.index = 0;
        }
    }

    private static T BufferGet((int, int, int, T, T[]) buffer, int val)
    {
        var (size, _, index, _, vals) = buffer;
        return vals[(Index) ((index + size - 1 + val) % size)];
    }

    private static void CalcTrueRange(T[] low, T[] high, T[] close, int i, out T trueRange)
    {
        T l = low[i];
        T h = high[i];
        T c = close[i - 1];
        T ych = T.Abs(h - c);
        T ycl = T.Abs(l - c);
        T v = h - l;
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

    private static void CalcDirection(T[] high, T[] low, int i, out T up, out T down)
    {
        up = high[i] - high[i - 1];
        down = low[i - 1] - low[i];

        if (up < T.Zero)
        {
            up = T.Zero;
        }
        else if (up > down)
        {
            down = T.Zero;
        }

        if (down < T.Zero)
        {
            down = T.Zero;
        }
        else if (down > up)
        {
            up = T.Zero;
        }
    }

    private static void Simple1(int size, T[] input, T[] output, Func<T, T> op)
    {
        for (var i = 0; i < size; ++i)
        {
            output[i] = op(input[i]);
        }
    }

    private static void Simple2(int size, T[] input1, T[] input2, T[] output, Func<T, T, T> op)
    {
        for (var i = 0; i < size; ++i)
        {
            output[i] = op(input1[i], input2[i]);
        }
    }
}
