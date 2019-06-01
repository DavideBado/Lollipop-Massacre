using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class Ability : MonoBehaviour
{
    public AbilityPatternData PatternData;
    /// <summary>
    /// Preview abilità senza raycast, comune a tutte le abilità, con data in ingresso 
    /// </summary>
    public void Preview()
    {
        PatternData.CurrentAbility.grid = GetComponent<Agent>().grid;
        PatternData.CurrentAbility.ClearList();
        PatternData.CurrentAbility.PlayerPosX = GetComponent<Agent>().x2;
        PatternData.CurrentAbility.PlayerPosZ = GetComponent<Agent>().y2;
        PatternData.CurrentAbility.CurrentDirection = GetComponent<Agent>().SavedlookAt;

        if(PatternData.CurrentAbility.CurrentDirection.z > 0)
        {
            PatternData.CurrentAbility.PlayerDirection(PlayerDirectionType.Up);
        }
        else if(PatternData.CurrentAbility.CurrentDirection.z < 0)
        {
            PatternData.CurrentAbility.PlayerDirection(PlayerDirectionType.Down);
        }
        else if(PatternData.CurrentAbility.CurrentDirection.x > 0)
        {
            PatternData.CurrentAbility.PlayerDirection(PlayerDirectionType.Right);
        }
        else if(PatternData.CurrentAbility.CurrentDirection.x < 0)
        {
            PatternData.CurrentAbility.PlayerDirection(PlayerDirectionType.Left);
        }
                
        foreach (DirectionType _direction in PatternData.CurrentAbility.directions)
        {
            PatternData.CurrentAbility.PatternDirection(_direction);
        }
        PatternData.CurrentAbility.ColorPreview();
    }  
}
