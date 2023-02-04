using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMusicScript : MonoBehaviour
{
    public AudioSource gameMusic, menuMusic;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    public void GameMusic()
    {
        gameMusic.volume = 1;
        menuMusic.volume = 0;
    }
    public void MenuMusic()
    {
        gameMusic.volume = 0;
        menuMusic.volume = 1;
    }
}
