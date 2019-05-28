﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public GridManager Gridmngr;
     public PlayerManager Playermngr;
     public TurnManager TurnMngr;

    /// <summary>
    /// setup dei manager
    /// </summary>
    public void Init()
    {
        Gridmngr.SetUp();
        Playermngr.Setup();
    }

    public void SetUp()
    {
        if (Gridmngr ==null)
        {
            Gridmngr = FindObjectOfType<GridManager>(); 
        }

        if (Playermngr == null)
        {
            Playermngr = FindObjectOfType<PlayerManager>(); 
        }

        if (TurnMngr == null)
        {
            TurnMngr = FindObjectOfType<TurnManager>();
        }
    }


}
