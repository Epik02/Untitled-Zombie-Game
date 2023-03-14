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

    //options menu
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider soundSlider;

    //Advanced options
    public Slider GunSlider;
    public Slider ReloadSlider;
    public Slider ExplodeSlider;

    //Base Values
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
        //Saves values between playthroughs, and thusly loads them at the beginning of the scene
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
        soundSlider.value = SoundVolume;          //initialize when slider is ready, also setup other sliders on deeper menu // Le Done
        GunSlider.value = GunshotVolume;
        ReloadSlider.value = ReloadVolume;
        ExplodeSlider.value = ExplodeVolume;

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
 
        //original function
        soundPlayer.volume = MasterVolume;

        //Updates your audio levels
        GunShotPlayer.volume = VolumeModified(GunShotPlayer.volume, VolumeModified(GunShotPlayer.volume, MasterVolume, SoundVolume), GunshotVolume);
        ReloadPlayer.volume = VolumeModified(ReloadPlayer.volume, VolumeModified(ReloadPlayer.volume, MasterVolume, SoundVolume), ReloadVolume);
        ExplodePlayer.volume = VolumeModified(ExplodePlayer.volume, VolumeModified(ExplodePlayer.volume, MasterVolume, SoundVolume), ExplodeVolume);

        //Debug.Log(GunshotVolume);
    }

    public void updateMaster( float volume)
    {
        MasterVolume = VolumeChanger(MasterVolume, volume);
        PlayerPrefs.SetFloat("volume", MasterVolume);
    }

    public void updateMusic( float volume)
    {
        MusicVolume = VolumeModified(MusicVolume, MasterVolume, volume);
        PlayerPrefs.SetFloat("musVolume", MusicVolume);
    }

    public void updateSound ( float volume)
    {
        SoundVolume = VolumeModified(SoundVolume, MasterVolume, volume);
        PlayerPrefs.SetFloat("souVolume", SoundVolume);
    }

    public void updateGunVol(float volume)
    {
        GunshotVolume = volume;
        PlayerPrefs.SetFloat("gunVolume", GunshotVolume);
    }

    public void updateRelVol(float volume)
    {
        ReloadVolume = volume;
        PlayerPrefs.SetFloat("relVolume", ReloadVolume);
    }

    public void updateExpVol(float volume)
    {
        ExplodeVolume = volume;
        PlayerPrefs.SetFloat("expVolume", ExplodeVolume);
    }
}
