using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCtrl : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audioClips = new List<AudioClip>();
    public Canvas VideoCanvas;
    public Canvas PlayingCanvas;

    public void PlayAudio(int id)
    {
        audioSource.clip = audioClips[id];
        audioSource.Play();
    }

    public void StartPlay()
    {
        PlayingCanvas.gameObject.SetActive(true);
        VideoCanvas.gameObject.SetActive(false);
    }

}
