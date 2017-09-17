using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationScript : MonoBehaviour
{
    [SerializeField]
    private Text Recognitions;

    private DictationRecognizer DictationRecognizer;

    void Start()
    {
      Recognitions.text = "";

      DictationRecognizer = new DictationRecognizer();

      DictationRecognizer.DictationResult += (text, confidence) =>
      {
        Debug.LogFormat("Dictation result: {0}", text);
        Recognitions.text = text;
      };

      DictationRecognizer.DictationComplete += (completionCause) =>
      {
        if (completionCause != DictationCompletionCause.Complete)
          Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
      };

      DictationRecognizer.DictationError += (error, hresult) =>
      {
        Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
      };

      DictationRecognizer.Start();
    }
  }