using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoMarkerList {
    public List<GeoMarker> gmarkers;
    public float radiusCheck;
    public Transform transform;
    public float earthRadius;
    private GameObject markerPrefab;
    public Transform earthTransform;

    public GeoMarkerList(float radius, Transform trans, Transform eTransform, float eRadius, GameObject prefab) {
        gmarkers = new List<GeoMarker>();
        transform = trans;
        earthRadius = eRadius;
        earthTransform = eTransform;
        markerPrefab = prefab;
        radiusCheck = radius;
    }

    public void AddNewMarker(Vector2 coords) {
        GeoMarker mark = new GeoMarker(coords, transform, earthTransform, earthRadius, markerPrefab);
        gmarkers.Add(mark);
    }

    public bool CheckCoords(float lat, float lon) {
        Vector2 coord = new Vector2(lat, lon);
        foreach (GeoMarker gmark in gmarkers) {
            //Debug.Log((gmark.geoCoordCenter - coord).sqrMagnitude);
            if ((gmark.geoCoordCenter - coord).sqrMagnitude <= radiusCheck * radiusCheck) {
                gmark.AddMarker(coord);
                return false;
            }
        }

        AddNewMarker(coord);
        return true;
    }

    public bool CheckMarker(GeoMarker marker) {
        foreach (GeoMarker gmark in gmarkers) {
            //Debug.Log((gmark.geoCoordCenter - marker.geoCoordCenter).sqrMagnitude);
            if ((gmark.geoCoordCenter - marker.geoCoordCenter).sqrMagnitude <= radiusCheck * radiusCheck) {
                gmark.AddFrom(marker);
                return false;
            }
        }

        gmarkers.Add(marker);
        return true;
    }

    public GeoMarkerList MergeCoords() {
        GeoMarkerList newGeoMarkerList = new GeoMarkerList(radiusCheck, transform, earthTransform, earthRadius, markerPrefab);
        foreach (GeoMarker gmark in gmarkers) {
            newGeoMarkerList.CheckMarker(gmark);
        }

        return newGeoMarkerList;
    }

    public int Count() {
        return gmarkers.Count;
    }
}