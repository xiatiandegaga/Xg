using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiClientProxy.Test.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : ControllerBase
    {
        private ITest _test;

        public TestController(ITest test)
        {
            _test = test;
        }
        //public void  Test()
        //{
        //    var paramsModel= new WeatherForecast { TemperatureC=1 };
        //    var wq =  _test.Get(paramsModel);
        //}
    }
}
