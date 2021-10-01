using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private int _score;
    private TMP_Text _scoreText;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<TMP_Text>(); 
        EventBroker.EnemyHit += UpdateScore;
        _scoreText.text = $"Score: {_score.ToString()}";
    }

    private void UpdateScore(int scorePoint)
    {
        _score += scorePoint;
        _scoreText.text = $"Score: {_score.ToString()}";
    }

    private void OnDisable()
    {
        EventBroker.EnemyHit -= UpdateScore;
    }
}
