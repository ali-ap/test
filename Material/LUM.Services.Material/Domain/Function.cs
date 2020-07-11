using System;
using System.Collections.Generic;
using LUM.Services.Material.Type;

namespace LUM.Services.Material.Domain
{
    public class Function : ValueObject
    {
        private Temperature _minTemperature = new Temperature(){Celsius = 4};
        private Temperature _maxTemperature = new Temperature() { Celsius = 80 };
        public Temperature MinTemperature
        {
            get => _minTemperature;
            set
            {
                if ( value.Celsius > _maxTemperature.Celsius)
                    throw new ArgumentException("min temperature can't be more than max temperature");
                _minTemperature = value;

            }
        }
        public Temperature MaxTemperature
        {
            get => _maxTemperature;
            set
            {
                if (value.Celsius < _minTemperature.Celsius)
                    throw new ArgumentException("max temperature can't be less than min temperature");
                _maxTemperature = value;

            }
        }


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return MinTemperature.Celsius;
            yield return MaxTemperature.Celsius;
        }
    }
}