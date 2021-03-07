using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsSFX : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonAudioSource;

    public void ExecuteButtonSound(AudioClip audioClip)
    {
        _buttonAudioSource.PlayOneShot(audioClip);
    }
}
