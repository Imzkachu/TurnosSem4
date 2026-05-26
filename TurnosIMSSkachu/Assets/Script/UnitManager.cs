using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class UnitManager : MonoBehaviour
{

    public static UnitManager Instance { get; private set; }


    private List<Unit> unitList;
    private List<Unit> friendlyUnitList;
    private List<Unit> enemyUnitList;

    public event EventHandler OnGameWin;
    public event EventHandler OnGameLose;


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UnitManager! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;

        unitList = new List<Unit>();
        friendlyUnitList = new List<Unit>();
        enemyUnitList = new List<Unit>();
    }

    private void Start()
    {
        Unit.OnAnyUnitSpawned += Unit_OnAnyUnitSpawned;
        Unit.OnAnyUnitDead += Unit_OnAnyUnitDead;
    }

    private void Unit_OnAnyUnitSpawned(object sender, EventArgs e)
    {
        Unit unit = sender as Unit;

        unitList.Add(unit);

        if (unit.IsEnemy())
        {
            enemyUnitList.Add(unit);
        } else
        {
            friendlyUnitList.Add(unit);
        }
    }

    private void Unit_OnAnyUnitDead(object sender, EventArgs e)
{
    Unit unit = sender as Unit;

    unitList.Remove(unit);

    if (unit.IsEnemy())
    {
        enemyUnitList.Remove(unit);
    }
    else
    {
        friendlyUnitList.Remove(unit);
    }

    CheckGameOver();
}

private void CheckGameOver()
{
    // Win condition
    if (enemyUnitList.Count == 0)
    {
        Debug.Log("YOU WIN!");
        OnGameWin?.Invoke(this, EventArgs.Empty);
        // Add your victory screen/UI here
        // Time.timeScale = 0f;
    }

    // Lose condition
    if (friendlyUnitList.Count == 0)
    {
        Debug.Log("GAME OVER!");
        OnGameLose?.Invoke(this, EventArgs.Empty);


        // Add your game over screen/UI here
        // Time.timeScale = 0f;
    }
}

    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public List<Unit> GetFriendlyUnitList()
    {
        return friendlyUnitList;
    }

    public List<Unit> GetEnemyUnitList()
    {
        return enemyUnitList;
    }

}
