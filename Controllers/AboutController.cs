using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_basic.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {

        public string Phone()
        {
            return "44353636";
        }

        public string Address()
        {
            return "USA-New York";
        }
    }
}