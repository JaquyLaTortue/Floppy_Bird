using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDisplayUi : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameUI;

    [SerializeField]
    private GameObject _end_UI;

    public void DisplayEndScreen()
    {
        _gameUI.SetActive(false);
        _end_UI.SetActive(true);
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
