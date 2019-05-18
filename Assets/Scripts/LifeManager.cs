using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using DG.Tweening;

public class LifeManager : MonoBehaviour
{
    public bool OnShield = false;
    public int Life = 3;
    GameManager GameManager;   
    bool CanRespawn = true;
    GameObject Graphic;
  
    // Start is called before the first frame update
    private void Start()
    {
        Graphic = GetComponentInChildren<AnimationController>().gameObject;
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
            if (_player.transform != transform)
            {
                m_OtherPLayer = _player;
            }
        }
        if (Life <= 0) // Se la vita è minore o uguale a 0
        {
            GameManager.EndGameCheck(GetComponent<Agent>().PlayerID, gameObject);

        }
    }

    public void Damage(int _amount)
    {
        Life -= _amount;
        GetComponent<XInputTestCS>().Damage = _amount;
        GetComponent<XInputTestCS>().Timer = (_amount * 0.2f);
        if (Graphic != null)
        {
            Graphic.transform.DOShakePosition(0.5f, 0.6f, 10, 45).SetAutoKill();
        }
    }

}
