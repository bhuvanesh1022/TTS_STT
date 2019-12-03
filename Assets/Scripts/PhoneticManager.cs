using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class PhoneticManager : MonoBehaviour
{
    public AudioClip audioClip;
    public SpeechManager speech;
    public List<GameObject> slots = new List<GameObject>();
    public string phoneme;
    public TextMeshProUGUI result;

    public void SpeakNow()
    {
        if (slots.Count != 0)
        {
            StartCoroutine(Speaking());
            result.text = "please wait...";
        }
    }

    IEnumerator Speaking()
    {
        string word = null;

        for (int i = 0; i < slots.Count; i++)
        {
            if (!slots[i].GetComponentInChildren<PhoneticManager>())
            {
                word += " ";
                //yield return new WaitForSeconds(.25f);
            }
            else
            {
                //For Google Translator

                word += slots[i].GetComponentInChildren<PhoneticManager>().phoneme;
                    
                //speech.Speak(slots[i].GetComponentInChildren<PhoneticManager>().audioClip);
                //yield return new WaitForSeconds(slots[i].GetComponentInChildren<PhoneticManager>().audioClip.length/1.5f);
            }
        }

        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q=" +
                word + "&tl=En-gb";
        UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.MPEG);

        yield return www.Send();
        result.text = word;

        if (!www.isNetworkError)
        {
            audioClip = DownloadHandlerAudioClip.GetContent(www);
        }
        speech.Speak(audioClip);
        yield return new WaitForSeconds(audioClip.length);
        result.text = "";
    }

}
