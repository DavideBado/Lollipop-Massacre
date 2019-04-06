using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{

    public Texture tex1, tex2;
    Agent player;
    public GameObject h1, h2, h3;
    public bool PanelPos;
    public GameManager gm;

    private void Start()
    {
        PoolFinder();
        if (gm = null)
        {
            gm = FindObjectOfType<GameManager>();
        }

        
    }

    private void Update()
    {
        TexSelector();
    }

    public void TexSelector()
    {
        //cuore 3
        if (player.GetComponent<LifeManager>().Life == 6)
        {
            h3.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 5)
        {
            h3.GetComponent<RawImage>().texture = tex2;
        }

        else if(player.GetComponent<LifeManager>().Life <= 4)
        {
            h3.GetComponent<RawImage>().texture = null;
        }

        //cuore 2
        if (player.GetComponent<LifeManager>().Life == 4)
        {
            h2.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 3)
        {
            h2.GetComponent<RawImage>().texture = tex2;
        }

        else if (player.GetComponent<LifeManager>().Life <= 2)
        {
            h2.GetComponent<RawImage>().texture = null;
        }

        //cuore 1
        if (player.GetComponent<LifeManager>().Life == 2)
        {
            h1.GetComponent<RawImage>().texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 1)
        {
            h1.GetComponent<RawImage>().texture = tex2;
        }

        else if (player.GetComponent<LifeManager>().Life == 0)
        {
            h1.GetComponent<RawImage>().texture = null;
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
