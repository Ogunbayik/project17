using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject nextLevelPanel;

    public enum GameStates
    {
        Start,
        InGame,
        GameOver,
        PassLevel
    }
    public GameStates currentState;
    void Start()
    {
        currentState = GameStates.Start;
    }

    public enum Panels
    {
        StartPanel,
        InGamePanel,
        GameOverPanel,
        NextLevelPanel
    }

    void Update()
    {
        switch(currentState)
        {
            case GameStates.Start: StartGame();
                break;
            case GameStates.InGame: InGame();
                break;
            case GameStates.GameOver: GameOver();
                break;
            case GameStates.PassLevel: NextLevel();
                break;
        }
    }

    private void GamePanel(Panels currentPanel)
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        nextLevelPanel.SetActive(false);

        switch(currentPanel)
        {
            case Panels.StartPanel: startPanel.SetActive(true);
                break;
            case Panels.InGamePanel: inGamePanel.SetActive(true);
                break;
            case Panels.GameOverPanel: gameOverPanel.SetActive(true);
                break;
            case Panels.NextLevelPanel: nextLevelPanel.SetActive(true);
                break;
        }
    }

    private void StartGame()
    {
        GamePanel(Panels.StartPanel);
    }

    private void InGame()
    {
        GamePanel(Panels.InGamePanel);
    }

    private void GameOver()
    {
        GamePanel(Panels.GameOverPanel);
    }

    private void NextLevel()
    {
        GamePanel(Panels.NextLevelPanel);
    }

}
