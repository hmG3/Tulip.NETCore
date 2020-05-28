using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tulip.NETCore.Tests
{
    public sealed class IndicatorsMapFixture
    {
        public IDictionary<string, Indicator> IndicatorsMap { get; }

        public IndicatorsMapFixture()
        {
            IndicatorsMap = typeof(Indicators)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Where(f => f.FieldType == typeof(Indicator))
                .Select(f => f.GetValue(null))
                .OfType<Indicator>()
                .ToDictionary(i => i.Name, i => i);
        }
    }
}
