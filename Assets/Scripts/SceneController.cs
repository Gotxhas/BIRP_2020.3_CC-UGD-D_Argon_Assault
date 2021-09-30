using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public float timeToLoadNewScene;

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
