using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PartyData
{
    public static float FirstPartyDev = 1f;
    public static List<GameObject> POnePart = new List<GameObject>();
    public static List<GameObject> PTwoPart = new List<GameObject>();

    public static void AddToParty(int m_PlayerID, GameObject m_Character)
    {
        if (m_PlayerID == 1)
        {
            POnePart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = POnePart.Count;
        }
        else if (m_PlayerID == 2)
        {
            PTwoPart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = PTwoPart.Count;
        }
    }

    public static int PartyCount(int m_PlayerID)
    {
        if (m_PlayerID == 1)
        {
            return POnePart.Count;
        }
        else if (m_PlayerID == 2)
        {
            return PTwoPart.Count;
        }
        else
        {
            return -1;
        }
    }
    
    public static void ClearData()
    {
        POnePart.Clear();
        PTwoPart.Clear();
    }

}
