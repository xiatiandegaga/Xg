using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClientProxy.Test
{
    public interface ITest
    {
        public IEnumerable<WeatherForecast> Get(WeatherForecast x);
    }
}
