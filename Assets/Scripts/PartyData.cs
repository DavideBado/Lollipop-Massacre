using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PartyData

{
    public static List<Agent> POneParty = new List<Agent>();
    public static List<Agent> PTwoParty = new List<Agent>();

    public static void AddToPartyOne(Agent Character)
    {
        POneParty.Add(Character);
    }

    public static int POnePartyCount()
    {
        return POneParty.Count;
    }


    public static void AddToPartyTwo(Agent Character)
    {
        PTwoParty.Add(Character);
    }

    public static int PTwoPartyCount()
    {
        return PTwoParty.Count;
    }

}
