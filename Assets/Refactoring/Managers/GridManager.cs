using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class GridManager : MonoBehaviour
{

    /// <summary>
    /// creazione della griglia
    /// </summary>
    public void SetUp()
    {
        
        GameManager.singleton.GetGridMngr().CreateGrid(Grid.ConfigData);
        
    }
}
