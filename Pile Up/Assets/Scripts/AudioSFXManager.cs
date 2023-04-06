using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSFXManager : MonoBehaviour
{
    public static AudioSFXManager Instance;

    [SerializeField] AudioClip[] soundEffects;
    AudioSource audioSource;

  

    private void Awake()
    {
        Instance = this;
        
        audioSource = GetComponent<AudioSource>();
    }

    
    

    public void PlaySFX(int clip)
    {
        audioSource.PlayOneShot(soundEffects[(clip)]);
    }

    public void MenuClick(int clipNumber)
    {
        PlaySFX(clipNumber);
    }
}

