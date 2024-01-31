using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int ScoreCount { get; private set; } = 0;

    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private BirdCollisions _birdCollisions;

    private void Start()
    {
        _birdCollisions.ScoreUp += AddScore;
        _scoreText.text = $"Score : {ScoreCount}";
    }

    /// <summary>
    /// Increment the score each time the Bird passes a pipe
    /// </summary>
    public void AddScore()
    {
        ScoreCount++;
        _scoreText.text = $"Score : {ScoreCount}";
    }
}
