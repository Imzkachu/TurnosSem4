using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TurnSystemUI : MonoBehaviour
{

    [SerializeField] private Button endTurnBtn;
    [SerializeField] private TextMeshProUGUI turnNumberText;
    [SerializeField] private GameObject enemyTurnVisualGameObject;
    private bool gameOver = false;
    [SerializeField] private GameObject gameOverVisualGameObject;
    [SerializeField] private GameObject victoryVisualGameObject;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;

    private void Start()
    {
        victoryVisualGameObject.SetActive(false);
        gameOverVisualGameObject.SetActive(false);

        endTurnBtn.onClick.AddListener(() =>
        {
            TurnSystem.Instance.NextTurn();
        });

        restartButton.onClick.AddListener(RestartGame);
        nextLevelButton.onClick.AddListener(LoadNextLevel);

        TurnSystem.Instance.OnTurnChanged += TurnSystem_OnTurnChanged;

        UnitManager.Instance.OnGameLose += UnitManager_OnGameLose;
        UnitManager.Instance.OnGameWin += UnitManager_OnGameWin;

        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisibility();
    }

    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        UpdateTurnText();
        UpdateEnemyTurnVisual();
        UpdateEndTurnButtonVisibility();
    }

    private void UpdateTurnText()
    {
        turnNumberText.text = "TURN " + TurnSystem.Instance.GetTurnNumber();
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex + 1
        );
    }

    private void UpdateEnemyTurnVisual()
    {
        enemyTurnVisualGameObject.SetActive(!TurnSystem.Instance.IsPlayerTurn());
    }

    private void UpdateEndTurnButtonVisibility()
    {
        endTurnBtn.gameObject.SetActive(TurnSystem.Instance.IsPlayerTurn());
    }
    private void UnitManager_OnGameLose(object sender, EventArgs e)
    {
        gameOver = true;
        endTurnBtn.interactable = false;
        UpdateGameOverVisual();
    }

    private void UnitManager_OnGameWin(object sender, EventArgs e)
    {
        gameOver = true;
        endTurnBtn.interactable = false;
        UpdateVictoryVisual();
    }
    
    private void UpdateGameOverVisual()
    {
        gameOverVisualGameObject.SetActive(true);
        victoryVisualGameObject.SetActive(false);
    }

    private void UpdateVictoryVisual()
    {
        victoryVisualGameObject.SetActive(true);
        gameOverVisualGameObject.SetActive(false);
    }


}
