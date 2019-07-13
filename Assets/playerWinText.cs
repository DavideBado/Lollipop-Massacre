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
       
    }

    private void Update()
    {
       
    }
    public void PlayerText(int index)
    {
        if(index == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
        }
        else if(index == 2)
        {
            player2.SetActive(true);
            player1.SetActive(false);
        }
        Time.timeScale = 0;
    }
}
