using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaUI : MonoBehaviour
{
    public Image img;
    public Sprite sp1, sp2;
    Agent player;
    public bool PanelPos;
    public GameManager gm;

    private void Start()
    {
        PoolFinder();
        if (gm = null)
        {
            gm = FindObjectOfType<GameManager>();
        }
        img = GetComponent<Image>();
    }

    private void Update()
    {
        manaSprite();
    }

    void manaSprite()
    {
        if (player.Mana == 1)
        {
            img.sprite = sp1;
        }

        else if (player.Mana == 0)
        {
            img.sprite = sp2;
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
