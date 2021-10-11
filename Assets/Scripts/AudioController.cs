using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{
    private void Awake()
    {
        int numMusicPlayers = FindObjectsOfType<AudioController>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    } 
}
