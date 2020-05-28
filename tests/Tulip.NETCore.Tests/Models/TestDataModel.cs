using System;

namespace Tulip.NETCore.Tests.Models
{
    public class TestDataModel<T> where T : struct
    {
        public string Name { get; set; }

        public T[][] Inputs { get; set; }

        public T[] Options { get; set; } = Array.Empty<T>();

        public T[][] Outputs { get; set; }

        public bool Skip { get; set; }

        public override string ToString() => Name;
    }
}
