using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicManager : MonoBehaviour
{

    public AudioSource bgm1;
    public AudioSource bgm2;

    bool bgm2Started = false;


    private void Update()
    {
        if (bgm2Started)
        {
            return;
        }


        if (!bgm1.isPlaying)
        {
            bgm2.Play();
            bgm2Started = true;
        }
    }
}
