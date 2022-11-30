using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class AudioManager : MonoBehaviour
{
    //Import Native C++ Library
    [DllImport("AUDIOHELPAH", EntryPoint = "VolumeChanger")]
    public static extern float VolumeChanger(float volume1, float volume2);

    [DllImport("AUDIOHELPAH", EntryPoint = "VolumeModified")]
    public static extern float VolumeModified(float volume1, float volume2, float volume3);

    public static AudioManager audioInstance;

    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource soundPlayer;

    public Slider masterSlider;
    public Slider musicSlider;
    private float MasterVolume = 1.00f;
    private float MusicVolume = 1.00f;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!audioInstance)
        {
            audioInstance = this;
           // Debug.Log("Ran Awake");
        }
    }

    private void Start()
    {
        MasterVolume = PlayerPrefs.GetFloat("volume");
        MusicVolume = PlayerPrefs.GetFloat("musVolume");


        musicPlayer.volume = VolumeModified(musicPlayer.volume, MasterVolume, MusicVolume);

        masterSlider.value = MasterVolume;
        musicSlider.value = MusicVolume;
        // Debug.Log("Ran Start");



    }

    public void PlaySound(AudioClip clip)
    {
        soundPlayer.PlayOneShot(clip);
    }


    // Dont Really need this section since our Bg is going to loop and we only have track music track atm.

    //public void PlayMusic(AudioClip clip)
    //{
    //    musicPlayer.PlayOneShot(clip);
    //}
    

    public void BgMusic()
    {
        musicPlayer.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        //currently only master volume, with more sliders it can be master volume, music, etc.
        musicPlayer.volume = VolumeModified(musicPlayer.volume, MasterVolume, MusicVolume);
        PlayerPrefs.SetFloat("musVolume", MusicVolume);

        //original function
        soundPlayer.volume = MasterVolume;
        PlayerPrefs.SetFloat("volume", MasterVolume);
    }

    public void updateMaster( float volume)
    {
        MasterVolume = VolumeChanger(MasterVolume, volume);
        //MasterVolume = volume;
    }

    public void updateMusic( float volume)
    {
        MusicVolume = VolumeModified(MusicVolume, MasterVolume, volume);
    }
}
