using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip MouseEnter;
    public AudioClip MouseDown;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMouseEnter() {
        audioSource.clip = MouseEnter;
        audioSource.Play();
    }
    public void PlayMouseDown() {
        audioSource.clip = MouseDown;
        audioSource.Play(0);
    }
}
