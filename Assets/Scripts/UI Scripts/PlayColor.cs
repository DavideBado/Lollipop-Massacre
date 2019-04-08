﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayColor : MonoBehaviour
{
  
    // Update is called once per frame
    void Update()
    {
      if(PartyData.POnePart.Count < 3 || PartyData.PTwoPart.Count < 3 )
        {
            GetComponent<Image>().color = Color.gray;
        }
      else
        {
            GetComponent<Image>().color = Color.white;
        }
    }
}
