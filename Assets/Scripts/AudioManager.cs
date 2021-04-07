using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //private static variable instance for AudioManager
    //public property to retrieve the audio manager instance
    //sheck if instance is null
    //error if it is, else return instance
    //assign the instance to "this" in void awake

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AudioManager is NULL");
            }

            return _instance;
        }

    }

    [SerializeField]
    private AudioSource _voiceOver;
    [SerializeField]
    private AudioSource _music;
    [SerializeField]
    private AudioSource _winMusic;
    [SerializeField]
    private AudioClip _winClip;



    private void Awake()
    {
        _instance = this;

        
    }

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        _voiceOver.clip = clipToPlay;
        _voiceOver.Play();

    }

    public void PlayMusic()
    {
        _music.Play();
    }


    public void PlayWin()
    {
        _winMusic.PlayOneShot(_winClip);
    }

    public void StopMusic()
    {
        _music.Stop();
    }

}


