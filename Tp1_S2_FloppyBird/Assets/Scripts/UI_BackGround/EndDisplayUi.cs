using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDisplayUi : MonoBehaviour
{
    [Header("references")]
    [SerializeField]
    private Score _score;

    [Header("Game UI")]
    [SerializeField]
    private GameObject _gameUI;

    [Header("End UI")]
    [SerializeField]
    private GameObject _end_UI;

    [SerializeField]
    private TMP_Text _scoreText;

    public void DisplayEndScreen()
    {
        _gameUI.SetActive(false);
        _end_UI.SetActive(true);
        _scoreText.text = $"Score : {_score.ScoreCount}";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
