using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PartyData

{
    public static List<Agent> POnePart = new List<Agent>();
    public static List<Agent> PTwoPart = new List<Agent>();

    public static void AddToParty(int m_PlayerID, Agent m_Character)
    {
        if (m_PlayerID == 1)
        {
            POnePart.Add(m_Character);
        }
        else if (m_PlayerID == 2)
        {
            PTwoPart.Add(m_Character);
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
