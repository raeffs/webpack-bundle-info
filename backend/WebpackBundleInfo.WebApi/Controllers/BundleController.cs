using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebpackBundleInfo.Bundles;

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

        [HttpGet]
        public async Task<IActionResult> GetBundles([FromQuery] GetBundlesRequest request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddBundle([FromBody] AddBundleRequest request, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpGet, Route("{commitSha}")]
        public async Task<IActionResult> GetBundle([FromRoute] string commitSha, CancellationToken cancellationToken)
        {
            var request = new GetBundleRequest { CommitSha = commitSha };
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }

        [HttpPost, Route("{commitSha}")]
        public async Task<IActionResult> CompareBundle([FromRoute] string commitSha, [FromBody] ICollection<BundleComponent> components, CancellationToken cancellationToken)
        {
            var request = new CompareBundleRequest { CommitSha = commitSha, Components = components };
            var response = await this.mediator.Send(request, cancellationToken);
            return this.Ok(response);
        }
    }
}
