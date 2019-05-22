using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSprite : MonoBehaviour
{

	

	public int ID;
    
    public Image img;
    public GameManager gm;
    public bool PanelPos;
    Agent player;


   
    void Start()
    {
        //img = GetComponent<RawImage>();

        //if (gm == null)
        //{
        //    gm = FindObjectOfType<GameManager>();
        //}

        //PoolFinder();
    }

    private void Update()
    {
		img = GetComponent<Image>();

		if (gm == null)
		{
			gm = FindObjectOfType<GameManager>();
		}

		PoolFinder();
		avatarSelection();
    }


    void avatarSelection()
    {
		img.sprite = player._Sprites[2];
        
    }



    void PoolFinder()
    {
		if (PanelPos == true)
		{
			player = gm.POneParty[ID].GetComponent<Agent>();
			
		}
		else if (PanelPos == false)
		{
		player = gm.PTwoParty[ID].GetComponent<Agent>();
		}
    }
}
