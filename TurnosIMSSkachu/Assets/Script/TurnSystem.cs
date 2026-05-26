using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{

    public static TurnSystem Instance { get; private set; }


    public event EventHandler OnTurnChanged;


    private int turnNumber = 1;
    private bool isPlayerTurn = true;
    private bool gameOver = false;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one TurnSystem! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        UnitManager.Instance.OnGameWin += UnitManager_OnGameWin;
        UnitManager.Instance.OnGameLose += UnitManager_OnGameLose;
    }

    public void NextTurn()
    {
        if (gameOver)
        {
            return;
        }

        turnNumber++;
        isPlayerTurn = !isPlayerTurn;

        OnTurnChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetTurnNumber()
    {
        return turnNumber;
    }

    public bool IsPlayerTurn()
    {
        return isPlayerTurn;
    }

    private void UnitManager_OnGameWin(object sender, EventArgs e)
    {
        gameOver = true;
        Debug.Log("Victory!");
    }

    private void UnitManager_OnGameLose(object sender, EventArgs e)
    {
        gameOver = true;
        Debug.Log("Defeat!");
    }
    
}
