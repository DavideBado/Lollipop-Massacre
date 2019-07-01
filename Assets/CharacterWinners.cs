using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterWinners : MonoBehaviour
{
    GameManager gm;
    public Image img0, img1, img2;

    private void OnEnable()
    {
        gm = FindObjectOfType<GameManager>();
        characterConfig();
    }

    public void characterConfig()
    {
        if (gm.p1win)
        {
            img0.sprite = gm.POneParty[0].GetComponent<Agent>()._Sprites[4];
            img1.sprite = gm.POneParty[1].GetComponent<Agent>()._Sprites[4];
            img2.sprite = gm.POneParty[2].GetComponent<Agent>()._Sprites[5];
        }
        else if (gm.p2win)
        {
            img0.sprite = gm.PTwoParty[0].GetComponent<Agent>()._Sprites[4];
            img1.sprite = gm.PTwoParty[1].GetComponent<Agent>()._Sprites[4];
            img2.sprite = gm.PTwoParty[2].GetComponent<Agent>()._Sprites[5];
        }
    }
}
