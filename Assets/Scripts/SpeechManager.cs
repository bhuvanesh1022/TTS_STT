using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechManager : MonoBehaviour
{
    private AudioSource audioSource;

    public int noOfSyllabes;
    public List<string> actualWords = new List<string>();
    public List<string> nonsenseWords = new List<string>();
    public List<AudioClip> correctAudio = new List<AudioClip>();
    public List<AudioClip> wrongAudio = new List<AudioClip>();
    public List<Transform> slots = new List<Transform>();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        noOfSyllabes = Mathf.Clamp(noOfSyllabes, 0, 3);
    }
    public void Speak(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Reload()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (slots[i].childCount > 0)
            {
                Transform child = slots[i].GetChild(0);

                child.parent = child.GetComponent<ItemDragHandler>().startParent;
                child.localPosition = child.GetComponent<ItemDragHandler>().startPosition;
            }
        }
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}

