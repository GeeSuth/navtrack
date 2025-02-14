import React, { useState, useEffect } from "react";
import { AssetApi } from "../../../apis/AssetApi";
import {
  DefaultGetLocationsModel,
  GetLocationsModel
} from "../../../apis/types/asset/GetLocationsModel";
import useAssetId from "../../../services/hooks/useAssetId";
import useMap from "../../../services/hooks/useMap";
import { MapService } from "../../../services/MapService";
import LocationFilter from "../../common/locationFilter/LocationFilter";
import { MapToLocationHistoryRequestModel } from "../../common/locationFilter/LocationFilterUtil";
import {
  DefaultLocationFilterModel,
  LocationFilterModel
} from "../../common/locationFilter/types/LocationFilterModel";
import AssetLocationsTable from "./AssetLocationsTable";

export default function AssetLocations() {
  useMap();
  const [locationFilter, setLocationFilter] = useState(DefaultLocationFilterModel);
  const [locations, setLocations] = useState<GetLocationsModel>(DefaultGetLocationsModel);
  const [selectedLocationIndex, setSelectedLocationIndex] = useState(0);
  const [loading, setLoading] = useState(true);
  const assetId = useAssetId();

  const updateLocations = (assetId: number, locationFilter: LocationFilterModel) => {
    setLoading(true);
    let filter = MapToLocationHistoryRequestModel(locationFilter, assetId);
    AssetApi.getLocations(assetId, filter)
      .then((x) => {
        setLocations(x);
        setSelectedLocationIndex(0);
      })
      .finally(() => setLoading(false));
  };

  useEffect(() => {
    if (assetId) {
      updateLocations(assetId, locationFilter);
    }
  }, [assetId, locationFilter]);

  useEffect(() => {
    let location = locations.results[selectedLocationIndex];
    if (location) {
      MapService.showMarker([location.latitude, location.longitude]);
    }
  }, [locations, selectedLocationIndex]);

  return (
    <>
      <LocationFilter filter={locationFilter} setFilter={setLocationFilter} />
      <AssetLocationsTable
        loading={loading}
        locations={locations.results}
        selectedIndex={selectedLocationIndex}
        setSelectedIndex={setSelectedLocationIndex}
      />
    </>
  );
}
