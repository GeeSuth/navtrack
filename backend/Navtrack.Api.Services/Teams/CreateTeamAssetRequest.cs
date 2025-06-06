using Navtrack.Api.Model.Teams;

namespace Navtrack.Api.Services.Teams;

public class CreateTeamAssetRequest
{
    public string TeamId { get; set; } = default!;
    public CreateTeamAsset Model { get; set; } = default!;
}