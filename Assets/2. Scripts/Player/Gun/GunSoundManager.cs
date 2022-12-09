using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSoundManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    public float pitch;
    public int i;
    public void SoundPlay()
    {
        pitch = Random.RandomRange(0.8f, 1.2f);
        audioSources[i].pitch = pitch;

        audioSources[i].Play();

        i++;
        if(i >= audioSources.Length)
        {
            i = 0;
        }        
    }
}
