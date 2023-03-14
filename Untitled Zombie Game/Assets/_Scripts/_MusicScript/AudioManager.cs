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
    [SerializeField] private AudioSource GunShotPlayer;
    [SerializeField] private AudioSource ReloadPlayer;
    [SerializeField] private AudioSource ExplodePlayer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;
    private float MasterVolume = 1.00f;
    private float MusicVolume = 1.00f;
    private float SoundVolume = 1.00f;
    private float GunshotVolume = 1.00f;
    private float ReloadVolume = 1.00f;
    private float ExplodeVolume = 1.00f;

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
        //Saves values between playthroughs
        MasterVolume = PlayerPrefs.GetFloat("volume");
        MusicVolume = PlayerPrefs.GetFloat("musVolume");
        SoundVolume = PlayerPrefs.GetFloat("souVolume");
        GunshotVolume = PlayerPrefs.GetFloat("gunVolume");
        ReloadVolume = PlayerPrefs.GetFloat("relVolume");
        ExplodeVolume = PlayerPrefs.GetFloat("expVolume");


        //Setup volume levels off of presets and other higher level sliders
        musicPlayer.volume = VolumeModified(musicPlayer.volume, MasterVolume, MusicVolume);
        //soundPlayer.volume = VolumeModified(soundPlayer.volume, MasterVolume, SoundVolume);



        GunShotPlayer.volume = VolumeModified(GunShotPlayer.volume, MasterVolume, SoundVolume);  //souVolume == 0 // fixed*
        ReloadPlayer.volume = VolumeModified(ReloadPlayer.volume, MasterVolume, SoundVolume);
        ExplodePlayer.volume = VolumeModified(ExplodePlayer.volume, MasterVolume, SoundVolume);
        // GunShotPlayer.volume = MasterVolume * SoundVolume * GunshotVolume;
       // ReloadPlayer.volume = MasterVolume * SoundVolume * ReloadVolume;


        //Sets sliders to saved values
        masterSlider.value = MasterVolume;
        musicSlider.value = MusicVolume;
        soundSlider.value = SoundVolume;          //initialize when slider is ready, also setup other sliders on deeper menu


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

        PlayerPrefs.SetFloat("souVolume", SoundVolume);

        GunShotPlayer.volume = VolumeModified(GunShotPlayer.volume, MasterVolume, SoundVolume) / 2;
        PlayerPrefs.SetFloat("gunVolume", GunshotVolume);
        ReloadPlayer.volume = 2*VolumeModified(ReloadPlayer.volume, MasterVolume, SoundVolume);
        PlayerPrefs.SetFloat("relVolume", ReloadVolume);
        ExplodePlayer.volume = VolumeModified(ExplodePlayer.volume, MasterVolume, SoundVolume);
        PlayerPrefs.SetFloat("expVolume", ExplodeVolume);

        //GunShotPlayer.volume = MasterVolume * SoundVolume * GunshotVolume;
        //ReloadPlayer.volume = MasterVolume * SoundVolume * ReloadVolume;

        //Debug.Log(SoundVolume);
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

    public void updateSound ( float volume)
    {
        SoundVolume = VolumeModified(SoundVolume, MasterVolume, volume);
    }
}
