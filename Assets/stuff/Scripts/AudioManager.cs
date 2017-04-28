using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string Name;
    public AudioClip clip;

    //give us a slider!
    [Range(0f,1f)]
    public float Volume = 0.7f;

    //And another one!
    [Range(0.5f, 1.5f)]
    public float Pitch = 1f;

    //And another one!
    [Range(0f, 0.5f)]
    public float RandomVolume = 0.1f;

    //And another one!
    [Range(0.5f, 1.5f)]
    public float RandomPitch = 0.1f;

    private AudioSource source;

    public void SetSource (AudioSource _Source)
    {
        source = _Source;
        source.clip = clip;
    }

    public void Play()
    {
        source.volume = Volume * (1 + Random.Range(-RandomVolume/2f, RandomVolume / 2f));
        source.pitch = Pitch * (1 + Random.Range(-RandomPitch / 2f, RandomPitch / 2f)); ;
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

    private void Start()
    {

        for (int index = 0; index < sounds.Length; index++)
        {
            //create a new gameobject with all the necessary informations
            GameObject _go = new GameObject("Sound_" + index + "_" + sounds[index].Name);

            //set parent to this object
            _go.transform.SetParent(this.transform);

            //add an audiosource component and set it to the source
            sounds[index].SetSource( _go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound(string _name)
    {
        //loop through all sounds
        for (int i = 0; i < sounds.Length; i++)
        {
            if(sounds[i].Name == _name)
            {
                sounds[i].Play();

                //exit out of the loop
                return;
            }
        }

        //no sound with _name
        Debug.LogError("AudioManager: sound not found");
    }

}
