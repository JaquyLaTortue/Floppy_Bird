using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] TMP_Text _scoreText;

    public void AddScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }
}
