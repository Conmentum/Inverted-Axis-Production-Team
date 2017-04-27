using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip clip;

    public float Volume = 0.7f;
    public float Pitch = 1f;

    private AudioSource source;

    public void SetSource (AudioSource _Source)
    {
        source = _Source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = Volume;
        source.pitch = Random.Range(0.5f, 1f);
        source.Play();
    }
}

public class AudioManager : MonoBehaviour {

    [SerializeField]
    Sound[] sounds;

    //create a singleton
    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(this);
        }

    }

}
