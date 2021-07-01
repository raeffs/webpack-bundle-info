using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebpackBundleInfo.Controllers
{
    [Route("api/bundles")]
    [ApiController]
    public class BundleController : ControllerBase
    {
        private readonly IMediator mediator;

        public BundleController(IMediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
