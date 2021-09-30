using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] private float levelLoadDelay = 1f;
    [SerializeField] private GameObject explosionPrefab;
    
    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath"); //Disable controllers in the PlayerController
        explosionPrefab.SetActive(true);
        Invoke(nameof(LoadScene), levelLoadDelay);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
