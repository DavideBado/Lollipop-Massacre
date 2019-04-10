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
        if (player.GetComponent<LifeManager>().Life == 6)
        {
			h3.GetComponent<RawImage>().enabled = true;
			h3.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 5)
        {
			h3.GetComponent<RawImage>().enabled = true;
			h3.GetComponent<RawImage>().texture = tex2;
        }

        else if(player.GetComponent<LifeManager>().Life <= 4)
        {
            h3.GetComponent<RawImage>().enabled = false;
        }

        //cuore 2
        if (player.GetComponent<LifeManager>().Life >= 4)
        {
			h2.GetComponent<RawImage>().enabled = true;
			h2.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 3)
        {
			h2.GetComponent<RawImage>().enabled = true;
			h2.GetComponent<RawImage>().texture = tex2;
        }

        else if (player.GetComponent<LifeManager>().Life <= 2)
        {
            h2.GetComponent<RawImage>().enabled = false;
        }

        //cuore 1
        if (player.GetComponent<LifeManager>().Life >= 2)
        {
			h1.GetComponent<RawImage>().enabled = true;
			h1.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 1)
        {
			h1.GetComponent<RawImage>().enabled = true;
			h1.GetComponent<RawImage>().texture = tex2;
			
		}

        else if (player.GetComponent<LifeManager>().Life == 0)
        {
            h1.GetComponent<RawImage>().enabled = false;
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