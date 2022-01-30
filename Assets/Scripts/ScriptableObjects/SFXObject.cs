using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SFXObject : ScriptableObject
{
    public List<SFXWithID> SoundBank = new List<SFXWithID>();

    private Dictionary<string, AudioClip> _soundDictionary;

    private void OnEnable()
    {
        _soundDictionary = new Dictionary<string, AudioClip>();
        foreach(SFXWithID sound in SoundBank)
        {
            _soundDictionary.Add(sound.ID, sound.SFX);
        }
    }

    public bool ContainsClip(string sfxID)
    {
        return _soundDictionary.ContainsKey(sfxID);
    }

    public AudioClip GetFromID(string id)
    {
        if (_soundDictionary.ContainsKey(id))
        {
            return _soundDictionary[id];
        }
        else
        {
            return null;
        }
    }

}

[System.Serializable]
public struct SFXWithID
{
    public string ID;
    public AudioClip SFX;
}
