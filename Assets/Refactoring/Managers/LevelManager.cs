using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{


    /// <summary>
    /// setup dei manager
    /// </summary>
    public void Init()
    {
        GameManager.singleton.GridMngr.SetUp();
        GameManager.singleton.PlayerMngr.ActiveStarters();
    }

    public void SetUp()
    {
        if (GameManager.singleton.GridMngr == null)
        {
            GameManager.singleton.GridMngr = FindObjectOfType<GridManager>(); 
        }

        if(GameManager.singleton.PlayerMngr == null)
        {
            GameManager.singleton.PlayerMngr = FindObjectOfType<PlayerManager>();
        }
    }


}
