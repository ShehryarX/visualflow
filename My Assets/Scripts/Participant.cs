using System.Collections;
using System.Collections.Generic;
using UnityEngine;



#if UNITY_EDITOR
using UnityEditor;
#endif

[System.Serializable]
public class Participant
{
    public static int markerCount;
    public int id;
    public string marital_status;
    public string sex;
    public float longitude;
    public string state;
    public string last_name;
    public string date_added;
    public string first_name;
    public string dental_flag;
    public string city;
    public int postal_code;
    public string birth_date;
    public float latitude;
    public string address_1;
    public string collection_id;
    public string _version_;

    public Participant CreateFromJSON(string jsonString)
    {
        markerCount++;
        return JsonUtility.FromJson<Participant>(jsonString);
    }

    public string toString()
    {
        return id + "/n" + marital_status + "/n" + sex + "/n" + longitude + "/n" + state + "/n" + last_name + "/n" + date_added + "/n" + first_name + "/n" + dental_flag + "/n" + city;
    }

    public void Start()
    {
        markerCount = 0;
    }

    public float getLongitude()
    {
        return longitude;
    }

    public float getLatitude()
    {
        return latitude;
    }



}
