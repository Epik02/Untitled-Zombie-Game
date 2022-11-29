using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioInstance;

    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource soundPlayer;

    public Slider masterSlider;
    private float MasterVolume = 1f;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!audioInstance)
        {
            audioInstance = this;
            Debug.Log("Ran Awake");
        }
    }

    private void Start()
    {
        MasterVolume = PlayerPrefs.GetFloat("volume");
        musicPlayer.volume = MasterVolume;
        masterSlider.value = MasterVolume;
        Debug.Log("Ran Start");



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
        musicPlayer.volume = MasterVolume;
        PlayerPrefs.SetFloat("volume", MasterVolume);

        soundPlayer.volume = MasterVolume;
        PlayerPrefs.SetFloat("volume", MasterVolume);
    }

    public void updateVolume( float volume)
    {
        MasterVolume = volume;
    }
}
