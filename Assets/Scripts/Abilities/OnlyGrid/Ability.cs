using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public AbilityPatternData PatternData;
    /// <summary>
    /// Preview abilità senza raycast, comune a tutte le abilità, con data in ingresso 
    /// </summary>
    private void Preview()
    {
        PatternData.CurrentAbility.PlayerPosX = GetComponent<Agent>().x;
        PatternData.CurrentAbility.PlayerPosZ = GetComponent<Agent>().y;
        PatternData.CurrentAbility.CurrentDirection = GetComponent<Agent>().SavedlookAt;
    }
}
