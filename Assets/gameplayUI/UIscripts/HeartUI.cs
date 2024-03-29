﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
	public int ID;
    public Sprite tex1, tex2;
    Agent player;
    public GameObject h1, h2, h3;
    public bool PanelPos;
	GameManager manager;


    private void Update()
    {
	if(manager == null)
	{
			manager = FindObjectOfType<GameManager>();
	}
		PoolFinder();
		TexSelector();
    }

    public void TexSelector()
    {
        //cuore 3
        if (player.GetComponent<LifeManager>().Life == 3)
        {			
            if(player.GetComponentInChildren<Poison>() != null)
            {
                h3.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[3];
            }
            else
            {
			    h3.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[0];
            }
        }
        else if(player.GetComponent<LifeManager>().Life <= 2)
        {
            h3.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[1];

        }
        //cuore 2
        if (player.GetComponent<LifeManager>().Life > 2)
        {
			h2.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[0];

        }
        else if(player.GetComponent<LifeManager>().Life == 2)
        {
            if (player.GetComponentInChildren<Poison>() != null)
            {
                h2.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[3];
            }
            else
            {
                h2.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[0];
            }
        }
        else if (player.GetComponent<LifeManager>().Life <= 1)
        {
            h2.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[1];

        }
        //cuore 1
        if (player.GetComponent<LifeManager>().Life > 1)
        {
            h1.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[0];
        }
        else if (player.GetComponent<LifeManager>().Life == 1)
        {
            if (player.GetComponentInChildren<Poison>() != null)
            {
                h1.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[3];
            }
            else
            {
                h1.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[0];
            }
        }

        else if (player.GetComponent<LifeManager>().Life <= 0)
        {
            h1.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSprites[1];
        }
    }

    void PoolFinder()
    {
        if (PanelPos == true)
        {
            player = manager.POneParty[ID].GetComponent<Agent>();
        }

        else if (PanelPos == false)
        {
            player = manager.PTwoParty[ID].GetComponent<Agent>();
        }
    }
}
