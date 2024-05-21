using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private BulletsPoolBird _bulletsPool;
    [SerializeField] private BulletsPoolEnemy _bulletsPoolEnemy;
    [SerializeField] private EnemiesPool _enemiesPool;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private Restarter _restarter;

    private float minValueTime = 0;

    private void OnEnable()
    {
        _bird.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += StartGame;
    }

    private void OnDisable()
    {
        _bird.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked += StartGame;
    }

    private void Start()
    {
        Time.timeScale = minValueTime;
    }

    private void OnGameOver()
    {
        Time.timeScale = minValueTime;

        _startScreen.Open();

        _restarter.RestartLevel();
    }

    private void StartGame()
    {
        float maxValueTime = 1;

        _startScreen.Close();

        Time.timeScale = maxValueTime;
    }
}
