using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerController : MonoBehaviour
{
    public float timeToLoadNewScene;

    private void Awake() 
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(LoadFirstScene), timeToLoadNewScene);
    }
    
    private void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
    
}
