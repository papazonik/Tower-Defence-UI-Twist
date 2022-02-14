using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance; //Singleton
    [SerializeField] private AudioSource effectAudioSource;

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip audioClip)
    {
        effectAudioSource.PlayOneShot(audioClip);
    }


    //public void PlaySound(Sound sound) 
    //{
    //    GameObject soundGameObject = new GameObject("Sound");
    //    AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
    //    //audioSource.PlayOneShot
    //}

}
