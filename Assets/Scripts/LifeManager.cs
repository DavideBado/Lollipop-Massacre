using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using DG.Tweening;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    DamageFeed DamageImage;
    float FeedbackTImer;
    public bool OnShield = false;
    public int Life = 3;
    GameManager GameManager;   
    bool CanRespawn = true;
    GameObject Graphic;
  
    // Start is called before the first frame update
    private void Start()
    {
        if (GetComponentInChildren<AnimationController>() != null)
        {
            Graphic = GetComponentInChildren<AnimationController>().gameObject; 
        }
        GameManager = FindObjectOfType<GameManager>();
        DamageImage = FindObjectOfType<DamageFeed>();
    }
    // Update is called once per frame
    void Update()
    {
        DieNow();
        if (DamageImage.GetComponent<Image>().enabled)
        {
            if (FeedbackTImer > 0)
            {
                FeedbackTImer -= Time.deltaTime;
                if (FeedbackTImer <= 0)
                {
                    DamageImage.GetComponent<Image>().enabled = false;
                }
            } 
        }
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

    public void Damage(Agent _enemy, int _amount, bool _baseAttack)
    {
        Life -= _amount;
        //DamageFeedback(_amount - 1);
        GetComponent<XInputTestCS>().Damage = _amount;
        GetComponent<XInputTestCS>().Timer = (_amount * 0.2f);
        if ((_enemy.GetComponent<Venom>() == null && _enemy.GetComponent<Poison>() == null && _enemy.GetComponent<Whirlwind>() == null) || _baseAttack == true)
        {
            Knockback(_enemy.SavedlookAt, _amount);
        }
        if (Graphic != null)
        {
            Graphic.transform.DOShakePosition(0.5f, 0.6f, 10, 45).SetAutoKill();
        }
    }

    void DamageFeedback(int _amount)
    {
        FeedbackTImer = 1f;
        DamageImage.transform.position = (transform.position + new Vector3(0, 2.5f));
        DamageImage.GetComponent<Image>().enabled = true;
        DamageImage.GetComponent<Image>().sprite = DamageImage.DamageSprites[_amount];
    }

    private void Knockback(Vector3 _enemyrotation, int _damage)
    {
        for (int i = 0; i < _damage; i++)
        {
            GetComponent<Agent>().x += (int)_enemyrotation.x;
            GetComponent<Agent>().y += (int)_enemyrotation.z;
            GetComponent<Agent>().Movement();
        }

    }
}
