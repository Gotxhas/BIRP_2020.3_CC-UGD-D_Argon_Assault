using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerController : MonoBehaviour
{
    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }
}
