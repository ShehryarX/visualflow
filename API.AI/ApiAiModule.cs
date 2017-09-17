using UnityEngine;
using System;
using ApiAiSDK;
using ApiAiSDK.Unity;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

public class ApiAiModule : MonoBehaviour {
    public WindowsVoice theVoice;
    private ApiAiUnity apiAiUnity;

    public string getStringInBetween(string outText, string targetBegin, string targetEnd) {
        int from = outText.IndexOf(targetBegin) + targetBegin.Length;
        int to = outText.LastIndexOf(targetEnd);

        return outText.Substring(from, to - from);
    }

    // Use this for initialization
    void Start () {
        Debug.Log("API AI Initialized.");

        const string ACCESS_TOKEN = "c1cb6e5396d04d6e8b1215ac0cfd55ac";

        var config = new AIConfiguration(ACCESS_TOKEN, SupportedLanguage.English);

        apiAiUnity = new ApiAiUnity();
        apiAiUnity.Initialize(config);

        SendText("Do you know what is the definition of insanity is?");
    }

    public void SendText(string text) {
        ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
            return true;
        };

        try {
            var response = apiAiUnity.TextRequest(text);
            if (response != null) {
                string outText = JsonConvert.SerializeObject(response);
                string targetBegin = "\"speech\":\"";
                string targetEnd = "\"},\"source\"";
                String result = getStringInBetween(outText, targetBegin, targetEnd);

                Debug.Log("Result: " + result);
                WindowsVoice.speak(result);
            } else {
                Debug.LogError("Response is null");
            }
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
    }
}
