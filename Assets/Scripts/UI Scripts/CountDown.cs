using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public GameObject ThisCanvas, Game, InGameTiles, Tiles;
    public TMP_Text Timer_txt, Player_txt, Starts_txt;
    public List<Material> PlayertxtMat = new List<Material>();
    private float timerCD = 4, timer = 2;

    private void Start()
    {
        Time.timeScale = 1;
        Player_txt.SetText("PLAYER " + ((int)PartyData.FirstPartyDev).ToString());
        Player_txt.fontMaterial = PlayertxtMat[((int)PartyData.FirstPartyDev - 1)];
    }
    private void Update()
    {
        if (timer <= 0)
        {
            Player_txt.enabled = false;
            Starts_txt.enabled = false;
            Timer_txt.enabled = true;
            Timer_txt.text = ((int)timerCD).ToString();
            timerCD -= Time.deltaTime;
            transform.Translate(new Vector3(0, 1 * Time.deltaTime));
            if(timerCD < 1)
            {
                Game.SetActive(true);
                Tiles.SetActive(false);
                InGameTiles.SetActive(true);
                ThisCanvas.SetActive(false);
            }
        }
        else timer -= Time.deltaTime;
    }    
}
