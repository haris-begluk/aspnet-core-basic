using Microsoft.AspNetCore.Mvc;

namespace aspnet_core_basic.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "44353636";
        }
        [Route("[action]")]
        public string Address()
        {
            return "USA-New York";
        }
    }
}