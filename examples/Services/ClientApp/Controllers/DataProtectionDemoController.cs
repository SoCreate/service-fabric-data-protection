using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [Route("[controller]")]
    public class DataProtectionDemoController : Controller
    {
        IDataProtector _protector;

        public DataProtectionDemoController(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("TestProtector");
        }

        public IActionResult Index()
        {
            var protectedPayload = _protector.Protect("my secret");
            var unprotectedPayload = _protector.Unprotect(protectedPayload);

            return Content($"Protected Payload: {protectedPayload} Unprotected Payload: {unprotectedPayload}");
        }
    }
}