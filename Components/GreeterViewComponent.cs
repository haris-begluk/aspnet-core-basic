using aspnet_core_basic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_basic.Components
{
    public class GreeterViewComponent :ViewComponent
    {
        private IGreeter _greeter;

        public GreeterViewComponent(IGreeter greeter)
        {
            _greeter = greeter;
        } 
        public IViewComponentResult Invoke()
        {
            var model = _greeter.GetMessageOfTheDay();
            return View("Default", model);
        }
    }
}
