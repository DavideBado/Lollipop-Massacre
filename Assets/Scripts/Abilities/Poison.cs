using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    private int MaxRounds = 3;
    bool RoundCheck, CanAttack, CanUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        RoundCheck = FindObjectOfType<GameManager>().Turn;
    }

    // Update is called once per frame
    void Update()
    {
        poison();
    }

    void poison()
    {
        if (transform.parent != null)
        {
            if (FindObjectOfType<GameManager>().Turn != RoundCheck && CanUpdate == true)
            {
                CanAttack = true;
                if (MaxRounds > 1)
                {
                    MaxRounds--;
                }
                CanUpdate = false;
            }
            else if (FindObjectOfType<GameManager>().Turn == RoundCheck)
            {
                CanUpdate = true;
            }

            if (MaxRounds == 1 && CanAttack == true && FindObjectOfType<GameManager>().Turn == RoundCheck)
            {
                MaxRounds--;
                transform.parent.GetComponent<LifeManager>().DamageAmount = 1;
                transform.parent.GetComponent<LifeManager>().Enemy = transform.parent.GetComponent<Agent>();
                transform.parent.GetComponent<LifeManager>().BaseAttack = false;
                transform.parent.GetComponent<LifeManager>().Damage();
                CanAttack = false;
            }

            if (MaxRounds == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

