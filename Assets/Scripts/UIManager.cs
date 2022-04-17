using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    [SerializeField] private GameObject _lose;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Button _restart;
    [SerializeField] private Transform _cubeHolder;

    private void Awake()
    {
        Time.timeScale = 0;
        _restart.onClick.AddListener(RestartGame);
        _playerMovement.OnGameStart += StartGame;
    }

    private void OnDisable()
    {
        _playerMovement.OnGameStart -= StartGame;
    }

    private void Update()
    {
        if(_cubeHolder.childCount == 0)
        {
            GameLose();
        }
    }

    private void StartGame()
    {
        _startText.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    private void GameLose()
    {
        _lose.SetActive(true);
        Time.timeScale = 0;
    }

}
