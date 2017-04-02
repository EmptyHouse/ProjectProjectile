using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class SoundEffect : MonoBehaviour {
    public AudioClip[] aClips = new AudioClip[1];
    public float[] aClipProbability = new float[1];

    public float minPitch = .95f;
    public float maxPitch = 1.05f;
    public float minVolume = .9f;
    public float maxVolume = 1f;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        if (aClipProbability.Length != aClips.Length)
        {
            float[] probTemp = new float[aClips.Length];
            for (int i = 0; i < aClips.Length; i++)
            {
                if (i < aClipProbability.Length)
                {
                    probTemp[i] = aClipProbability[i];
                }
                else
                {
                    probTemp[i] = 0;
                }
            }
            aClipProbability = probTemp;
        }
        aClipProbability = CustomMath.weightArray(aClipProbability);
    }

    public void playSound()
    {
        aSource.Stop();
        aSource.Play();
    }

    public void playRandomSound()
    {
        aSource.Stop();
        randomizeSound();
        aSource.Play();
    }

    public void randomizeSound()
    {
        aSource.pitch = Random.Range(minPitch, maxPitch);
        aSource.volume = Random.Range(minVolume, maxVolume);
        aSource.clip = getRandomClip();
    }

    public AudioClip getRandomClip()
    {
        float randVal = Random.Range(0f, 1f);
        int i;
        for (i = 0; i < aClipProbability.Length; i++)
        {
            if (randVal < aClipProbability[i])
            {
                return aClips[i];
            }
        }
        return aClips[i];
    }

    public void setVolume(float volume)
    {
        aSource.volume = volume;
    }

    public void setPitch(float pitch)
    {
        aSource.pitch = pitch;
    }

    public void setClip(int clip)
    {
        if (aClips.Length == 0) return;

        aSource.clip = aClips[clip % aClips.Length];
    }
}
