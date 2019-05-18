using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterName : MonoBehaviour
{
    public int ID;
    Agent player;
    GameManager manager;
    public TMP_Text CharaName;
    public bool PanelPos;

    // Update is called once per frame
    void Update()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
        PoolFinder();
        TextUpdate();
    }

    void TextUpdate()
    {
        CharaName.text = player.CharacterName;
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
