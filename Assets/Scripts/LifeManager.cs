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
    public int DamageAmount;
    public Agent Enemy;
    public bool BaseAttack;

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
            GetComponentInChildren<AnimationController>().Death();         
        }
    }

    public void Damage()
    {
        if (Enemy != null)
        {
            transform.LookAt(Enemy.transform.position);
        }
        Enemy.OnAttack = false;
        if (DamageAmount > 0)
        {
            GetComponentInChildren<AnimationController>().Damage();
            Life -= DamageAmount;
            DamageFeedback();
            GetComponent<XInputTestCS>().Damage = DamageAmount;
            GetComponent<XInputTestCS>().Timer = (DamageAmount * 0.2f);
            if ((Enemy.GetComponent<Venom>() == null && Enemy.GetComponent<Poison>() == null && Enemy.GetComponent<Whirlwind>() == null) || BaseAttack == true)
            {
                Knockback(Enemy.SavedlookAt);
            }
            if (Graphic != null)
            {
                Graphic.transform.DOShakePosition(0.5f, 0.6f, 10, 45).SetAutoKill();
            }
            DamageAmount = 0;
        }
    }

    void DamageFeedback()
    {
        FeedbackTImer = 1f;
        DamageImage.transform.position = (transform.position + new Vector3(0, 2.5f));
        DamageImage.GetComponent<Image>().enabled = true;
        DamageImage.transform.parent.transform.parent = transform;
        DamageImage.GetComponent<Image>().sprite = DamageImage.DamageSprites[(DamageAmount - 1)];
    }

    private void Knockback(Vector3 _enemyrotation)
    {
        for (int i = 0; i < DamageAmount; i++)
        {
            GetComponent<Agent>().x += (int)_enemyrotation.x;
            GetComponent<Agent>().y += (int)_enemyrotation.z;
            GetComponent<Agent>().Movement();
        }
    }

    private void CleanTiles()
    {
        GameManager.CleanTiles();
        GameManager.UpdateTilesMat();
    }
}
