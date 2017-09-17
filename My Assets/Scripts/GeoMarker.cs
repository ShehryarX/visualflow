using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoMarker {
    public List<Vector2> geoCoords;
    public Vector2 geoCoordCenter;
    public Transform transform;
    public float earthRadius;
    public GameObject obj;
    private GameObject markerPrefab;
    public Transform earthTransform;

    public GeoMarker(Vector2 beginCoord, Transform trans, Transform eTransform, float eRadius, GameObject prefab) {
        geoCoords = new List<Vector2>();
        transform = trans;
        earthRadius = eRadius;
        markerPrefab = prefab;
        earthTransform = eTransform;
        AddMarker(beginCoord);
        CreateMarker();
    }

    public GeoMarker(GeoMarker markA, GeoMarker markB, Transform trans, Transform eTransform, float eRadius, GameObject prefab) {
        geoCoords = new List<Vector2>();
        geoCoords.AddRange(markA.geoCoords);
        geoCoords.AddRange(markB.geoCoords);
        calculateCenter();

        transform = trans;
        earthRadius = eRadius;
        markerPrefab = prefab;
        earthTransform = eTransform;
        CreateMarker();
    }



    private void CreateMarker() {
        // move marker to position
        Vector3 initPosition = getPositionInWorld();
        obj = UnityEngine.Object.Instantiate(markerPrefab, initPosition, Quaternion.identity);
        obj.transform.parent = earthTransform;
        obj.transform.LookAt(transform);
        obj.transform.Rotate(270, 0, 0);
        obj.SetActive(true);
    }

    public void AddMarker(Vector2 newCoord) {
        geoCoords.Add(newCoord);
        calculateCenter();
    }

    public void AddFrom(GeoMarker marker) {
        foreach (Vector2 coord in marker.geoCoords) {
            AddMarker(coord);
        }
    }

    private void calculateCenter() {
        foreach (Vector2 coord in geoCoords)
            geoCoordCenter += coord;
        geoCoordCenter /= geoCoords.Count;
    }

    public Vector3 getPositionInWorld() {
        float latitude = Mathf.PI * geoCoordCenter.x / 180;
        float longitude = Mathf.PI * geoCoordCenter.y / 180;

        // adjust position by radians
        latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

        // and switch z and y (since z is forward)
        float xPos = (earthRadius + (markerPrefab.transform.localScale.x / 2)) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
        float zPos = (earthRadius + (markerPrefab.transform.localScale.x / 2)) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
        float yPos = (earthRadius + (markerPrefab.transform.localScale.x / 2)) * Mathf.Cos(latitude);

        return new Vector3(xPos, yPos, zPos);
    }

    public void reposition() {
        calculateCenter();
        obj.transform.position = getPositionInWorld();
    }
}