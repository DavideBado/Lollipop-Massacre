using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public TMP_Text Timer_txt, Player_txt;
    private float timer = 3;

    private void Start()
    {
        Timer_txt.text = "PLAYER" + PartyData.FirstPartyDev;
    }
    private void Update()
    {
        Timer_txt.text = ((int)timer).ToString();
        timer -= Time.deltaTime;
    }    
}
