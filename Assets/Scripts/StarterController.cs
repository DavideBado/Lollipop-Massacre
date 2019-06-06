using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarterController : MonoBehaviour
{
   public void SelectPlayer()
    {
        float selector = ((float)(Random.Range(1, 3)) / 2);
        PartyData.FirstPartyDev += selector;
        if (PartyData.FirstPartyDev > 2)
        {
            PartyData.FirstPartyDev = 1;
        }
        else if (selector == 1)
            PartyData.FirstPartyDev = (int)PartyData.FirstPartyDev;
    }
}
