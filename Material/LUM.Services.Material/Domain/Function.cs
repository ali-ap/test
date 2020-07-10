using System.Collections.Generic;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Domain
{
    public class Function:ValueObject
    {
        public Temperature MinTemperature { get; set; }
        public Temperature MaxTemperature { get; set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MinTemperature.Celsius;
            yield return MaxTemperature.Celsius;
        }
    }
}