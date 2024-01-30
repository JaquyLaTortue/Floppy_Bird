using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private BirdCollisions _birdCollisions;

    private void Start()
    {
        _birdCollisions.ScoreUp += AddScore;
        _scoreText.text = $"Score : {_score}";
    }

    /// <summary>
    /// Increment the score each time the bird passes a pipe
    /// </summary>
    public void AddScore()
    {
        Debug.Log("Score Up");
        _score++;
        _scoreText.text = $"Score : {_score}";
    }
}
