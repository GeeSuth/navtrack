using System;
using System.Collections.Generic;
using System.Linq;
using Navtrack.Api.Model.Custom;
using Navtrack.Api.Model.Devices;

namespace Navtrack.Api.Model.Assets
{
    public class AssetModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Online => Location != null && Location.DateTime > DateTime.Now.AddMinutes(-2);

        public DeviceResponseModel ActiveDevice => Devices?.FirstOrDefault(x => x.IsActive);
        public IEnumerable<DeviceResponseModel> Devices { get; set; }
        public LocationResponseModel Location { get; set; }
    }
}