using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private const int MAX_ACTION_POINTS = 2;

	
    private GridPosition gridPosition;
    private int actionPoints = MAX_ACTION_POINTS;

    [SerializeField] private bool isEnemy;
	
	private void Awake()
	{
        
        
	}
	
	private void Start()
	{
		// leemos en donde está la unidad
		
		//Le avisamos al grid del nivel que tiene una unidad en esa posición


        // Evento de cuando se muera la unidad
        // Avisamos que una unidad nueva fue creada
	}
	
	void Update()
	{
		// vemos donde está ahorita la unidad
			
		// preguntamos si esta posición es diferente que la guardada
	}
	
    /*
    public T GetAction<T>() where T : BaseAction
    {
        foreach (BaseAction baseAction in baseActionArray)
        {
            if (baseAction is T)
            {
                return (T)baseAction;
            }
        }
        return null;
    }
    */

	public GridPosition GetGridPosition()
	{
		return gridPosition;
	}
	
	/*public BaseAction[] GetBaseActionArray()
	{
		return baseActionArray;
	}*/

	public Vector3 GetWorldPosition()
    {
        return transform.position;
    }

    /*
	public bool TrySpendActionPointsToTakeAction(BaseAction baseAction)
    {
        if (CanSpendActionPointsToTakeAction(baseAction))
        {
            SpendActionPoints(baseAction.GetActionPointsCost());
            return true;
        } else
        {
            return false;
        }
    }*/

    /*
	public bool CanSpendActionPointsToTakeAction(BaseAction baseAction)
    {
        if (actionPoints >= baseAction.GetActionPointsCost())
        {
            return true;
        } else
        {
            return false;
        }
    }*/

    /*
    private void SpendActionPoints(int amount)
    {
        actionPoints -= amount;

        OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
    }*/

    public int GetActionPoints()
    {
        return actionPoints;
    }

    /*
    private void TurnSystem_OnTurnChanged(object sender, EventArgs e)
    {
        if ((IsEnemy() && !TurnSystem.instancia.IsPlayerTurn()) ||
            (!IsEnemy() && TurnSystem.instancia.IsPlayerTurn()))
        {
            actionPoints = ACTION_POINTS_MAX;

            OnAnyActionPointsChanged?.Invoke(this, EventArgs.Empty);
        }
    }*/

    public bool IsEnemy()
    {
        return isEnemy;
    }

    /*
    public void Damage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }*/

    /* nuevo
    private void HealthSystem_OnDead(object sender, EventArgs e)
    {
        LevelGrid.Instance.RemoveUnitAtGridPosition(gridPosition, this);

        Destroy(gameObject);

        OnAnyUnitDead?.Invoke(this, EventArgs.Empty);
    }*/
    
    /* nuevo
    public float GetHealthNormalized()
    {
        return healthSystem.GetHealthNormalized();
    }*/

}
