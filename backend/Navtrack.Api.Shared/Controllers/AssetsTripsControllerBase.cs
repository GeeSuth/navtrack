using System.Threading.Tasks;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Navtrack.Api.Model;
using Navtrack.Api.Model.Trips;
using Navtrack.Api.Services.ActionFilters;
using Navtrack.Api.Services.Trips;
using Navtrack.DataAccess.Model.Assets;

namespace Navtrack.Api.Shared.Controllers;

[ApiController]
[Authorize(IdentityServerConstants.LocalApi.PolicyName)]
public abstract class AssetsTripsControllerBase(ITripService service) : ControllerBase
{
    [HttpGet(ApiPaths.AssetsAssetTrips)]
    [ProducesResponseType(typeof(TripListModel), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [AuthorizeAsset(AssetRoleType.Viewer)]
    public virtual async Task<JsonResult> GetTrips([FromRoute] string assetId, [FromQuery] TripFilterModel filter)
    {
        TripListModel locations = await service.GetTrips(assetId, filter);

        return new JsonResult(locations);
    }
}