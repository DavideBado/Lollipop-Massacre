using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSprite : MonoBehaviour
{

    //ButtonCustom1 bc;


    public Sprite s1, s2, s3, s4, s5, s6;
    public Image img;
    public GameManager gm;
    public bool PanelPos;
    Agent player;


    //private void OnEnable()
    //{
    //    bc.OnChangeCharacter += HandleOnChangeCharacter;
    //}

    //public void HandleOnChangeCharacter()
    //{
    //    if (bc.OnChangeCharacter != null)
    //    {
    //        avatarSelection();
    //    }
    //}

    //private void OnDisable()
    //{
    //    bc.OnChangeCharacter -= HandleOnChangeCharacter;

    //}

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if (gm = null)
        {
            gm = FindObjectOfType<GameManager>();
        }

        PoolFinder();
    }

    private void Update()
    {
        avatarSelection();
    }


    void avatarSelection()
    {
        if (player.PlayerType == 1)
        {
            img.sprite = s1;
        }

        else if (player.PlayerType == 2)
        {
            img.sprite = s2;
        }

        else if (player.PlayerType == 3)
        {
            img.sprite = s3;
        }

        else if (player.PlayerType == 4)
        {
            img.sprite = s4;
        }

        else if (player.PlayerType == 5)
        {
            img.sprite = s5;
        }

        else if (player.PlayerType == 6)
        {
            img.sprite = s6;
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
