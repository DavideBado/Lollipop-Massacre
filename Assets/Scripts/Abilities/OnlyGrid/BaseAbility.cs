using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BaseAbility
{
    private Vector3 lookUp = new Vector3(0, 0, 1);
    private Vector3 lookDown = new Vector3(0, 0, -1);
    private Vector3 lookLeft = new Vector3(-1, 0, 0);
    private Vector3 lookRight = new Vector3(1, 0, 0);

    [NonSerialized]
    public int PlayerPosX, PlayerPosZ;
    [NonSerialized]
    public Vector3 CurrentDirection;

    public List<DirectionType> directions = new List<DirectionType>();
    [Range (-1, 4)] public int Range;
    [Range (-1, 6)] public int ExtRange;
    [Range (0, 1)] public int Lateral;

    private DirectionType direction;

    public void PlayerDirection(DirectionType _direction)
    {
        switch (_direction)
        {
            case DirectionType.Up:
                CurrentDirection = lookUp;
                break;
            case DirectionType.Down:
                CurrentDirection = lookDown;
                break;
            case DirectionType.Left:
                CurrentDirection = lookLeft;
                break;
            case DirectionType.Right:
                CurrentDirection = lookRight;
                break;
            default:
                break;
        }
    }
}
public enum DirectionType
{
    Up,
    Down,
    Left,
    Right
}

