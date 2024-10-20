using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source--------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip--------")]
    public AudioClip background;
    public AudioClip fallSound;
    public AudioClip coinCollect;
    public AudioClip jumpSound;
    public AudioClip Check;
    public AudioClip portalIh;
    public AudioClip portalOut;
    public AudioClip Spikes_;

    
    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
 public void PlaySFX(AudioClip clip)
{

        SFXSource.PlayOneShot(clip); 
 }
}