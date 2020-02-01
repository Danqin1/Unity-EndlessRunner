using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip pickUp;
    public AudioClip Track1Music;
    public AudioClip dead;
    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("Volume");
        audioSource = GetComponent<AudioSource>();
        PlayTrack1Music();
    }
    public void PlayTrack1Music()
    {
        audioSource.PlayOneShot(Track1Music,1f);
    }
    public void PlayPickUp()
    {
        audioSource.PlayOneShot(pickUp,0.5f);
    }
    public void DeadMusic()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(dead,0.3f);
    }
}
