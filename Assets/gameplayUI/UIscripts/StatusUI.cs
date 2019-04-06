using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    public Agent player;
    
    public Image statusimg;
    public Sprite sprite1, sprite2;
    public GameManager gm;
    public bool PanelPos;


    private void Start()
    {
        if (gm = null)
        {
            gm = FindObjectOfType<GameManager>();
        }
        PoolFinder();
        statusimg = GetComponent<Image>();
    }

    private void Update()
    {
        statusSprite();
        
    }

    void statusSprite()
    {
        
        if(player.ImStunned == true)
        {
            statusimg.sprite = sprite1;
        }

        else if (player.GetComponentInChildren<Poison>() != null)
        {
            statusimg.sprite = sprite2;
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
            player = PartyData.POnePart[2].GetComponent<Agent>();
        }

        else if (PanelPos == false)
        {
            player = PartyData.PTwoPart[2].GetComponent<Agent>();
        }
    }
}
