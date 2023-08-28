using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Coins _coins;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Score _score;

    public void OnGameOver()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _player.GameOver += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _player.GameOver -= OnGameOver;
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1.0f;
        _player.Reset();
        _coins.Reset();
        _score.Reset();
    }
}
