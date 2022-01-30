using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BeauRoutine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private SFXObject sfxObject;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioSource MusicLayer1Source;
    [SerializeField] private AudioSource MusicLayer2Source;
    [SerializeField] private AudioSource MusicLayer3Source;
    [SerializeField] private float fadeInTime = 1f;


    int layerIndex = 0;

    private AudioSource[] sources;

    //Starts music from the beginning, resetting all audio sources, and playing Layer 1
    public void StartMusic()
    {
        layerIndex = 0;

        MusicLayer1Source.volume = 1f;
        MusicLayer1Source.time = 0f;
        MusicLayer1Source.Play();

        MusicLayer2Source.volume = 0f;
        MusicLayer2Source.time = 0f;
        MusicLayer2Source.Play();

        MusicLayer3Source.volume = 0f;
        MusicLayer3Source.time = 0f;
        MusicLayer3Source.Play();

        sources = new AudioSource[] { MusicLayer1Source, MusicLayer2Source, MusicLayer3Source };
    }

    //Fades in the next layer of the music. Does nothing if all layers are playing
    public void AddLayer()
    {
        layerIndex++;

        AudioSource nextLayer = sources[layerIndex];

        Routine.Start(nextLayer.VolumeTo(1f, fadeInTime));
    }

    public void PlaySFX(string id)
    {
        if (!sfxObject.ContainsClip(id)) return;
        SFXSource.clip = sfxObject.GetFromID(id);
        SFXSource.Play();
    }

    public void PlaySFXOneShot(string id, float volume = 1f)
    {
        if (!sfxObject.ContainsClip(id)) return;
        SFXSource.PlayOneShot(sfxObject.GetFromID(id), volume);
    }

}
