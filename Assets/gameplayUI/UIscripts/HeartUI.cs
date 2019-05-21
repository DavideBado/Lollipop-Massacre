﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
	public int ID;
    public Texture tex1, tex2;
    Agent player;
    public GameObject h1, h2, h3;
    public bool PanelPos;
	


    private void Update()
    {
	
		//PoolFinder();
		TexSelector();
    }

    public void TexSelector()
    {
        //cuore 3
        if (player.GetComponent<LifeManager>().Life == 3)
        {
			h3.GetComponent<RawImage>().enabled = true;
			h3.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[0];
        }


        else if(player.GetComponent<LifeManager>().Life <= 2)
        {
            h3.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[1];

        }

        //cuore 2
        if (player.GetComponent<LifeManager>().Life >= 2)
        {
			h2.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[0];

        }
        

        else if (player.GetComponent<LifeManager>().Life <= 1)
        {
            h2.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[1];

        }

        //cuore 1
        if (player.GetComponent<LifeManager>().Life >= 1)
        {
			h1.GetComponent<RawImage>().enabled = true;
            h1.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[0];
        }

        else if (player.GetComponent<LifeManager>().Life <= 0)
        {
            h1.GetComponent<RawImage>().texture = player.GetComponent<Agent>().LifeSprites[1];
        }
    }

    //void PoolFinder()
    //{
    //    if (PanelPos == true)
    //    {
    //        player = manager.POneParty[ID].GetComponent<Agent>();
    //    }

    //    else if (PanelPos == false)
    //    {
    //        player = manager.PTwoParty[ID].GetComponent<Agent>();
    //    }
    //}
}
