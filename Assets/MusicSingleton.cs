using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSingleton : MonoBehaviour
{
    private static MusicSingleton instance = null;
    private static AudioSource source = null;

    public static MusicSingleton Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            SetActive(true);

            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            source = instance.GetComponent<AudioSource>();
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void Restart()
    {
        source.Stop();
        source.Play();
    }

    public void SetActive(bool val)
    {
        if (val && !source.isPlaying)
            source.Play();
        else if (!val && source.isPlaying)
            source.Stop();
    }

    // any other methods you need
}