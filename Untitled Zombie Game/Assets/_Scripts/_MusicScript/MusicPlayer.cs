using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicClip;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.audioInstance.BgMusic();
        //musicVolume = PlayerPrefs.GetFloat("volume");
    }

    
}
