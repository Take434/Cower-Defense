using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using UnityEngine;
using UnityEngine.UI;

public enum GameStateEnum
{
    PLAYING,
    PAUSED,
    GAMEOVER
}

public class GameState : MonoBehaviour
{
    public GameStateEnum state = GameStateEnum.PAUSED;
    public GameObject pauseButton;
    public GameOverScreen gameOverScreen;
    public int Round = 1;
    private Image pauseButtonSprite;
    private Sprite[] pauseButtonStates;
    private EconomyController economyController;

    public void Start() {
        pauseButtonSprite = pauseButton.GetComponent<Image>();
        pauseButtonStates = UnityEngine.Resources.LoadAll<Sprite>("Sprites/PauseButton/");
        economyController = GameObject.Find("Economy").GetComponent<EconomyController>();
    }

    public void TogglePause() {
        if(state == GameStateEnum.PLAYING) {
            Pause();
        } else if(state == GameStateEnum.PAUSED) {
            Unpause();
        }
    }

    public void Pause() {
        state = GameStateEnum.PAUSED;
        pauseButtonSprite.sprite = pauseButtonStates[0];
    }

    public void Unpause() {
        state = GameStateEnum.PLAYING;
        pauseButtonSprite.sprite = pauseButtonStates[1];
    }

    public void GameOver()
    {
        state = GameStateEnum.GAMEOVER;
        gameOverScreen.Open();
    }

    public void RoundFinished()
    {
        Round++;
        economyController.EndOfWave();
        economyController.ReloadMoneyText();
        Pause();
    }

    public void RoundStarted()
    {
        Unpause();
    }
}
