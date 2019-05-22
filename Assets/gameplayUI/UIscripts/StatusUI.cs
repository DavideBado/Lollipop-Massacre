using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    Agent player;
    Image statusimg;
    public Sprite Stunned, Poisoned;
    public GameManager manager;
    public int ID;
    public bool PanelPos;




    private void Update()
    {
        statusimg = GetComponent<Image>();
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
        PoolFinder();
        statusSprite();
        
    }

    void statusSprite()
    {
        
        if(player.ImStunned == true || player.OhStunnedShit == true)
        {
			statusimg.enabled = true;
			statusimg.sprite = Stunned;
        }

        else if (player.GetComponentInChildren<Poison>() != null)
        {
			statusimg.enabled = true;
			statusimg.sprite = Poisoned;
        }

        else
        {
            statusimg.enabled = false;
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
