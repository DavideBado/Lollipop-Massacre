using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class GridManager : MonoBehaviour
{
    public BaseGrid Grid;
    private void Awake()
    {
        if (Grid == null)
        {
            Grid = GetComponent<BaseGrid>(); 
        }
    }
    /// <summary>
    /// creazione della griglia
    /// </summary>
    public void SetUp()
    {
        
        Grid.CreateGrid(Grid.ConfigData);
        
    }
}
