using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LoadMarkerAtLatLong : MonoBehaviour
{

    public GameObject prefab; // participant object
    public List<GameObject> markers = new List<GameObject>();
    public int markerCount = 0;
    public static float earthRadius = 20; // Earth ball radius (unity units)
    private float latitude; // lat
    private float longitude; // long
    /*public float xPos = 0;
    public float yPos = 0;
    public float zPos = 0;*/
    public GeoMarkerList geoMarkers;
    public Transform earthTransform;

    public float minimumRadius = 1f;

    // Use this for initialization
    void Start()
    {
        geoMarkers = new GeoMarkerList(minimumRadius, this.transform, earthTransform, earthRadius, prefab);

        Participant[] participants = ParticipantImporter.getParticipants();

        drawMarkers(participants, "yellow01", "male");
    }

    public void drawMarkers(Participant[] participants, string material, string filterData)
    {
        prefab.GetComponent<Renderer>().sharedMaterial = Resources.Load("Materials/Colors/" + material, typeof(Material)) as Material;
        Debug.Log(prefab.GetComponent<Renderer>().sharedMaterial);
        StartCoroutine("loadMarkers", participants);
    }

    IEnumerator loadMarkers(Participant[] participants)
    {

        foreach (Participant element in participants)
        {
            latitude = element.getLatitude();
            longitude = element.getLongitude();
            geoMarkers.CheckCoords(latitude, longitude);
            if (Time.frameCount % 50 == 0) {
                geoMarkers = geoMarkers.MergeCoords();
            }
            markerCount = geoMarkers.Count();
            //if (!(done1.Contains(latitude) && done2.Contains(longitude)))
            //{
                //done1.Add(latitude);
                //done2.Add(longitude);


                /*//Set position of marker
                latitude = Mathf.PI * latitude / 180;
                longitude = Mathf.PI * longitude / 180;

                // adjust position by radians
                latitude -= 1.570795765134f; // subtract 90 degrees (in radians)

                // and switch z and y (since z is forward)
                xPos = (radius + (prefab.transform.localScale.x / 2)) * Mathf.Sin(latitude) * Mathf.Cos(longitude);
                zPos = (radius + (prefab.transform.localScale.x / 2)) * Mathf.Sin(latitude) * Mathf.Sin(longitude);
                yPos = (radius + (prefab.transform.localScale.x / 2)) * Mathf.Cos(latitude);

                // move marker to position
                markers.Add(Instantiate(prefab, new Vector3(xPos, yPos, zPos), Quaternion.identity));
                markers[markerCount].transform.LookAt(transform);
                markers[markerCount].transform.Rotate(270, 0, 0);
                markers[markerCount].SetActive(true);
                markerCount++;*/
            //}

            yield return null;
        }

    }
}
