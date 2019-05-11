using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public RawImage img;
    public Texture sp1, sp2;
    Agent player;
    public bool PanelPos;
    public GameManager gm;
    public int ID;


    private void Update()
    {
        //img = GetComponent<RawImage>();
        if (gm == null)
        {
            gm = FindObjectOfType<GameManager>();
        }
        PoolFinder();
        manaSprite();
        
        
    }

    void manaSprite()
    {
        if (player.Mana == 1)
        {
            //img.texture = sp1;
            GetComponent<RawImage>().texture = player.EnergySprites[0];
        }

        else if (player.Mana == 0)
        {
            //img.texture = sp2;
            GetComponent<RawImage>().texture = player.EnergySprites[1];
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
