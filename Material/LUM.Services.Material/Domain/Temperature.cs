using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUM.Services.Material.Domain
{
    public struct Temperature
    {
        private float _celsius;
        public float Celsius
        {
            get => _celsius;
            set
            {
                if (value < 4 || value > 80)
                    throw new ArgumentException("Temperature value Must be between 4 - 80");
                _celsius = (float)(Math.Floor(value * 10) / 10);

            }
        }
    }

}

