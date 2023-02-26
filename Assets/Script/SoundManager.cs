using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance => _instance;
    public static bool hasInstance => _instance != null;
    [SerializeField] private Sound[] sounds;
    public enum SoundName
    { 
       BG1,
       BG2,
       BG3,
       Gunshot,
       MainMenu,
       PickUpitem,
       Player_Die,
       ReloadGun,
       Zombie_bite,
       Zombie_Die,
       Insect_Die
       
       
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        
    }
    
    public void Play(SoundName name)
    {
        Sound sound = GetSound(name);
        if (sound.audioSource == null)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.loop = sound.loop;
        }
        sound.audioSource.Play();
    }

    private Sound GetSound(SoundName name)
    {
        return System.Array.Find(sounds, s => s.name == name);
    }
}
