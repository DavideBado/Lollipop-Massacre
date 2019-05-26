using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeartUIBench : MonoBehaviour
{
    public int ID;   
    Agent player;
    public GameObject Heart;
    public bool PanelPos;
    GameManager manager;
    public TMP_Text LifeText;


    private void Update()
    {
        if (manager == null)
        {
            manager = FindObjectOfType<GameManager>();
        }
        PoolFinder();
        TexSelector();
    }

    public void TexSelector()
    {
        LifeText.text = player.GetComponent<LifeManager>().Life.ToString();
        
        if (player.GetComponent<LifeManager>().Life > 0)
        {
            Heart.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSpritesBench[0];
        }
        else
        {
            Heart.GetComponent<Image>().sprite = player.GetComponent<Agent>().LifeSpritesBench[1];
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