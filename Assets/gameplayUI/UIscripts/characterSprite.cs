using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSprite : MonoBehaviour
{
    public Sprite s1, s2, s3, s4, s5, s6;
    public Image img;
    public GameManager gm;
    public bool PanelPos;
    Agent player;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();

        if(gm = null)
        {
            gm = FindObjectOfType<GameManager>();
        }
        
        PoolFinder();
    }

    // Update is called once per frame
    void Update()
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
            player = gm.POneParty[2].GetComponent<Agent>();
        }

        else if (PanelPos == false)
        {
            
            player = gm.PTwoParty[2].GetComponent<Agent>();
        }
    }
}
