using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitcherUI : MonoBehaviour
{
    Agent player;
    
    RawImage statusimg;
    public Texture A, B, Y;
    OldGameManager manager;
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
        
        if(player.SwitchIndex == 1)
        {
			statusimg.enabled = true;
			statusimg.texture = A;
        }

		else if (player.SwitchIndex == 2)
		{
			statusimg.enabled = true;
			statusimg.texture = B;
		}
		else if(player.SwitchIndex == 3)

		{
			statusimg.enabled = true;
			statusimg.texture = Y;
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
