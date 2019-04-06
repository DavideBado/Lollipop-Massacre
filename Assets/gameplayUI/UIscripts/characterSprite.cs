using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterSprite : MonoBehaviour
{
    public Sprite s1, s2, s3, s4, s5, s6;
    public Image img;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        avatarSelection();
    }

    void avatarSelection()
    {
        if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 1)
        {
            img.sprite = s1;
        }

        else if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 2)
        {
            img.sprite = s2;
        }

        else if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 3)
        {
            img.sprite = s3;
        }

        else if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 4)
        {
            img.sprite = s4;
        }

        else if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 5)
        {
            img.sprite = s5;
        }

        else if (gm.POneParty[2].GetComponent<Agent>().PlayerType == 6)
        {
            img.sprite = s6;
        }
    }
}
