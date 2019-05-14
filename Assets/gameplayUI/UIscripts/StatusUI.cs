using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    Agent player;
    
    public RawImage statusimg;
    public Texture sprite1, sprite2;
    public OldGameManager manager;
    public int ID;
    public bool PanelPos;




    private void Update()
    {
        statusimg = GetComponent<RawImage>();
        if (manager == null)
        {
            manager = FindObjectOfType<OldGameManager>();
        }
        PoolFinder();
        statusSprite();
        
    }

    void statusSprite()
    {
        
        if(player.ImStunned == true)
        {
			statusimg.enabled = true;
			statusimg.texture = sprite1;
        }

        else if (player.GetComponentInChildren<Poison>() != null)
        {
			statusimg.enabled = true;
			statusimg.texture = sprite2;
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
