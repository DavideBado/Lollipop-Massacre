using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemData
{

    public enum Type { Wall, Player, Area, Cell}

    public Vector3 GridPosition;
    public Type ItemType;

}
