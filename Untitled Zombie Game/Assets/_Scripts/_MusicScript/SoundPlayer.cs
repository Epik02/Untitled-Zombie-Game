using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip soundClip;

    // Start is called before the first frame update
    void Start()
    {
      //  AudioManager.audioInstance.PlaySound(soundClip);
    }

}
