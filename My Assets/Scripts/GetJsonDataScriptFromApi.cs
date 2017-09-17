using UnityEngine;
using System.Collections;
using System.IO;

public class GetJsonDataScriptFromAPI : MonoBehaviour
{
    // Use this for initialization
    string Url;
    string path;
    StreamWriter writer;
    void Start()
    {
        Url = "https://v3v10.vitechinc.com/solr/participant/select?indent=on&q=*:*&wt=json&rows=100";
        GetData();
        /*string path = "Assets/Resources/participants.json";

        //Write some text to the test.txt file
        writer = new StreamWriter(path, true);
        */

    }

    // Update is called once per frame
    void Update()
    {

    }
    //Invoke this function where to want to make request.
    void GetData()
    {
        //sending the request to url
        WWW www = new WWW(Url);
        StartCoroutine("GetdataEnumerator", www);
    }
    IEnumerator GetParticipantsEnumerator(WWW www)
    {
        //Wait for request to complete
        yield return www;
        if (www.error == null)
        {
            string serviceData = www.text;
            //Data is in json format, we need to parse the Json.
            Debug.Log(serviceData);
            /*
            writer.WriteLine(www.text);
            writer.Close();
            */
            Debug.Log("Creating markers");
            
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}