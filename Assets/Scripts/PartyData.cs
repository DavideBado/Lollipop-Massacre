using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PartyData

{
    public static List<Agent> POnePart = new List<Agent>();
    public static List<Agent> PTwoPart = new List<Agent>();

    public static void AddToPartyOne(Agent Character)
    {
        POnePart.Add(Character);
    }

    public static int POnePartyCount()
    {
        return POnePart.Count;
    }


    public static void AddToPartyTwo(Agent Character)
    {
        PTwoPart.Add(Character);
    }

    public static int PTwoPartyCount()
    {
        return PTwoPart.Count;
    }

}
