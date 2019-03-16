﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    public Agent agent;
    public Color manacolor;
    
    // Start is called before the first frame update
    void Start()
    {
        manacolor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.Mana == 0)
        {
            manacolor = Color.white;
        }
        else
        {
            manacolor = Color.green;
        }
    }
}
