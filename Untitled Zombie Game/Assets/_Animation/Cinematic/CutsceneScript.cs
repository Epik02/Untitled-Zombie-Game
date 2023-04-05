using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class CutsceneScript : MonoBehaviour
{
    public VideoPlayer Video;
    public GameObject _texture;
    bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        //Video.playOnAwake = false;
        if (firstTime == true)
        {
            PlayVid();
        }
       

    }

    // Update is called once per frame
    void Update()
    {
        if (Video.isPaused == true)
        {
            _texture.SetActive(false);
            firstTime = false;
        }
        else if (Video.isPlaying == true)
        {
            _texture.SetActive(true);

            if (Input.anyKey)
            {
                Video.Pause();
            }
        }

    }

    public void PlayVid()
    {
        Video.Stop();
        Video.Play();
    }


}
