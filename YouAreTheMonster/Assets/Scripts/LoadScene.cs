using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private float fadeSpeed;

    [SerializeField] private bool playAudioClip;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;

    public void Load()
    {
        if(playAudioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
        Initiate.Fade(sceneToLoad, Color.black, fadeSpeed);
    }
}
