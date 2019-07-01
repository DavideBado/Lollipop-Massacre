using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerWinText : MonoBehaviour
{
    public GameObject player1, player2;
    GameManager gm;

    private void OnEnable()
    {
        gm = FindObjectOfType<GameManager>();
        PlayerText();
    }


    public void PlayerText()
    {
        if(gm.p1win == true)
        {
            player1.SetActive(true);
        }
        else if(gm.p2win == true)
        {
            player2.SetActive(true);
        }
    }
}
