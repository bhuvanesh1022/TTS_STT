using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TTS_Manager : MonoBehaviour
{
    public AudioSource audioSource;
    public TMP_InputField inputField;

    IEnumerator TTS()
    {
        string url = "https://translate.google.com/translate_tts?ie=UTF-8&total=1&idx=0&textlen=32&client=tw-ob&q="+inputField.text+"&tl=En-gb";
        WWW www = new WWW(url);

        yield return www;

        audioSource.clip = www.GetAudioClip(false, true, AudioType.MPEG);
        audioSource.Play();
    }

    public void SpeakNow()
    {
        StartCoroutine(TTS());
    }
}
