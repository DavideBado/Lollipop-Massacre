using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public GridManager Gridmngr;

    /// <summary>
    /// setup dei manager
    /// </summary>
    public void Init()
    {
        Gridmngr.SetUp();
    }

    public void SetUp()
    {
        if (Gridmngr ==null)
        {
            Gridmngr = FindObjectOfType<GridManager>(); 
        }
    }


}
