using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSprite : MonoBehaviour
{
	public int ID;
    public Image CharacterImage, EnergyImage, LifeImage;
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
		CharacterImage = GetComponent<Image>();

		if (gm == null)
		{
			gm = FindObjectOfType<GameManager>();
		}

		PoolFinder();
		avatarSelection();
    }


    void avatarSelection()
    {
        if(player.GetComponent<LifeManager>().Life > 0)
        {
            CharacterImage.sprite = player._InGameUIDamage[player.GetComponent<LifeManager>().Life - 1];
            if (EnergyImage != null && LifeImage != null)
            {
                EnergyImage.enabled = true;
                LifeImage.gameObject.SetActive(true); 
            }
        }
        else
        {
            CharacterImage.sprite = player.LifeSprites[2];
            if (EnergyImage != null && LifeImage != null)
            {
                EnergyImage.enabled = false;
                LifeImage.gameObject.SetActive(false); 
            }
        }        
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
