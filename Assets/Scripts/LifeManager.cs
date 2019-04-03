using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class LifeManager : MonoBehaviour
{
    public bool OnShield = false;
    public int Life = 3;
    GameManager GameManager;   
    bool CanRespawn = true;
    // Start is called before the first frame update
    private void Start()
    {
        Life = 6;
        GameManager = FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        DieNow();
    }

    void DieNow()
    {
        List<PlayerData> m_Players = FindObjectsOfType<PlayerData>().ToList();
        PlayerData m_OtherPLayer = null;
        foreach (PlayerData _player in m_Players)
        {
            if(_player.transform != transform)
            {
                m_OtherPLayer = _player;
            }
        }
        if (Life <= 0) // Se la vita è minore o uguale a 0
        {
            GameManager.EndGameCheck(GetComponent<Agent>().PlayerID);
            
        }
    }
}
