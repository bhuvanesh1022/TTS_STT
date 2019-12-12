using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsHandler : MonoBehaviour
{
    public GameObject panel;
    public SpeechManager speechManager;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public List<OptionsCtrl> options = new List<OptionsCtrl>();
    public AudioClip modifiedClip;
    public PhoneticManager phonetic;

    public void ChangePhoneme()
    {
        phonetic.audioClip = modifiedClip;
        speechManager.Speak(modifiedClip);
        panel.SetActive(false);
    }

    public void ShowOptions()
    {
        panel.SetActive(true);
    }

    public void AssignPhoneme()
    {
        for (int i = 0; i < options.Count; i++)
        {
            if (options[i].isSelected)
            {
                modifiedClip = audioClips[i];
                speechManager.Speak(audioClips[i]);
            }
        }
    }
}
