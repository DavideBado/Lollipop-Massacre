using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Abilitypattern", menuName = "Ability/Pattern", order = 1)]
public class AbilityPatternData : ScriptableObject
{
    public BaseAbility CurrentAbility;
}
