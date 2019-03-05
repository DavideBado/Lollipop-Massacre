using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public int MaxRounds = 2;
    bool RoundCheck, CanAttack;
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
        if(transform.parent != null)
        {
            if(FindObjectOfType<GameManager>().Turn != RoundCheck)
            {
                CanAttack = true;
            }

            if (MaxRounds > 0 && CanAttack == true && FindObjectOfType<GameManager>().Turn == RoundCheck)
            {
                transform.parent.GetComponent<LifeManager>().Life--;
                CanAttack = false;
                MaxRounds--;
            }

            if(MaxRounds == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
