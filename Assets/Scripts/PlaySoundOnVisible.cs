using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnVisible : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void OnEnable()
    {
        if (SoundManager.Instance)
        {
            SoundManager.Instance.PlaySound(audioClip);
        }
    }
}
