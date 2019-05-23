using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PartyData

{
    public static void AddToParty(int m_PlayerID, GameObject m_Character)
    {
        if (m_PlayerID == 1)
        {
            GameManager.singleton.POnePart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = GameManager.singleton.POnePart.Count;
        }
        else if (m_PlayerID == 2)
        {
            GameManager.singleton.PTwoPart.Add(m_Character);
            m_Character.GetComponent<Agent>().SwitchIndex = GameManager.singleton.PTwoPart.Count;
        }
    }

    public static int PartyCount(int m_PlayerID)
    {
        if (m_PlayerID == 1)
        {
            return GameManager.singleton.POnePart.Count;
        }
        else if (m_PlayerID == 2)
        {
            return GameManager.singleton.PTwoPart.Count;
        }
        else
        {
            return -1;
        }
    }
    
    public static void ClearData()
    {
        GameManager.singleton.POnePart.Clear();
        GameManager.singleton.PTwoPart.Clear();
    }

}
