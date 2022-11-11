using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public AudioSource AudioSource;

    public Slider volumeSlider;

    //Value from the slider, and it converts to volume level
    private float musicVolume = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        AudioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;
    }

    // Update is called once per frame
    private void Update()
    {
        AudioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

    public void updateVolume( float volume)
    {
        musicVolume = volume;
    }
}
