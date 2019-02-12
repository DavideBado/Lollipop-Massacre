using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTest2 : MonoBehaviour
{
    public PositionTester1 Player2;
    public int StartingRound;
    public bool ShieldRoundCheck = false;
    public KeyCode Type1, Type2, Type3, Type4, Type5, Type6;
    public int PlayerType, Energy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TypeSelector();
        if (ShieldRoundCheck == true)
        {
            ShieldOff();
            ShieldRoundCheck = false;
        }
    }

    void Attack2()
    {
        if (PlayerType == 1 && Player2._Round == true)
        {
            // Shield
            GetComponent<LifeManager>().OnShield = true;
            ShieldRoundCheck = true; // Nonla mette true
            StartingRound = GameObject.Find("GameManager").GetComponent<GameManager>().RoundCount;
            
        }
        else if (PlayerType == 2 && Player2._Round == true && GetComponent<LifeManager>().Life < 3)
        {
            // Life++
            GetComponent<LifeManager>().Life++;
        }
        else if (PlayerType == 3)
        {
            // Stun
        }
        else if (PlayerType == 4)
        {
            // Poison
        }
        else if (PlayerType == 5)
        {
            // Big damage
        }
        else if (PlayerType == 6)
        {
            // Boh
        }
    }

    void TypeSelector()
    {
        if (Input.GetKeyDown(Type1))
        {
            PlayerType = 1;
        }
        else if (Input.GetKeyDown(Type2))
        {
            PlayerType = 2;
        }
        else if (Input.GetKeyDown(Type3))
        {
            PlayerType = 3;
        }
        else if (Input.GetKeyDown(Type4))
        {
            PlayerType = 4;
        }
        else if (Input.GetKeyDown(Type5))
        {
            PlayerType = 5;
        }
        else if (Input.GetKeyDown(Type6))
        {
            PlayerType = 6;
        }
    }

    void ShieldOff()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().RoundCount == StartingRound + 2)
        {
            GetComponent<LifeManager>().OnShield = false;
        }
    }
}

