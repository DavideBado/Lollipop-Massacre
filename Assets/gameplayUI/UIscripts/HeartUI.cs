using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{

    public Texture tex1, tex2;
    public Agent player;
    public RawImage h1, h2, h3;
    public bool PanelPos;
    public GameManager gm;

    private void Start()
    {
        PoolFinder();
        gm = FindObjectOfType<GameManager>();
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
            h3.texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 5)
        {
            h3.texture = tex2;
        }

        else
        {
            h3.enabled = false;
        }

        //cuore 2
        if (player.GetComponent<LifeManager>().Life == 4)
        {
            h2.texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 3)
        {
            h2.texture = tex2;
        }

        else
        {
            h2.enabled = false;
        }

        //cuore 1
        if (player.GetComponent<LifeManager>().Life == 2)
        {
            h1.texture = tex1;
        }

        else if (player.GetComponent<LifeManager>().Life == 1)
        {
            h1.texture = tex2;
        }

        else
        {
            h1.enabled = false;
        }
    }

    void PoolFinder()
    {
        if (PanelPos == true)
        {
            player = gm.POneParty[2].GetComponent<Agent>();
        }

        else if (PanelPos == false)
        {
            player = gm.PTwoParty[2].GetComponent<Agent>();
        }
    }
}
