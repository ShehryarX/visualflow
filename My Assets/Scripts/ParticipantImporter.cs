using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ParticipantImporter : MonoBehaviour {

    public static Participant[] participants;
    public static int participantCount;

    // Use this for initialization
    void Start() {
        participants = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static Participant[] getParticipants ()
    {
        if (participants == null)
        {
            ParseParticipentsDB();
        }
        return participants;
    }

    public static int getParticipantCount ()
    {
        return participantCount;
    }

    private static void ParseParticipentsDB()
    {

        //Wait for request to complete
        string fileText = File.ReadAllText("Assets/Resources/Vitech Data/Participants.txt");

        fileText = "{\"Items\":" + fileText + "}";

        participants = JsonHelper.FromJson<Participant>(fileText);
        participantCount = participants.Length;


    }

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        /*
        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(T[] array, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
        */

        [System.Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
