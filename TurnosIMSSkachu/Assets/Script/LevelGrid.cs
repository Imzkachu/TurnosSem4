using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    //private GridSystem<GridObject> gridSystem;
    private GridSystem gridSystem;

    void Awake()
    {
        //gridSystem = new GridSystem<GridObject>(10,10,1,(GridSystem<GridObject>global, GridPosition gridPosition) => new GridObject(global, gridPosition));
        gridSystem = new GridSystem (10,10,1);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
