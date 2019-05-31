using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GridSystem;

[Serializable]
public class BaseAbility
{
    private Vector3 lookForward;
    private Vector3 lookBackward;
    private Vector3 lookLeft;
    private Vector3 lookRight;

    [NonSerialized]
    public List<List<CellPrefScript>> CellsList = new List<List<CellPrefScript>>();

    [NonSerialized]
    public BaseGrid grid;
    [NonSerialized]
    public int PlayerPosX, PlayerPosZ;
    [NonSerialized]
    public Vector3 CurrentDirection;

    public List<DirectionType> directions = new List<DirectionType>();
    [Range (-1, 4)] public int Range;
    [Range (-1, 6)] public int ExtRange;
    [Range (0, 1)] public int Lateral;

    private DirectionType direction;

    /// <summary>
    /// Funzione che imposta i vettori della preview in base alla direzione del player
    /// </summary>   
    public void PlayerDirection(PlayerDirectionType _direction)
    {
        switch (_direction)
        {
            case PlayerDirectionType.Up:
                lookForward = Vector3.forward;
                lookBackward = Vector3.back;
                lookLeft = Vector3.left;
                lookRight = Vector3.right;
                break;
            case PlayerDirectionType.Down:
                lookForward = Vector3.back;
                lookBackward = Vector3.forward;
                lookLeft = Vector3.right;
                lookRight = Vector3.left;
                break;
            case PlayerDirectionType.Left:
                lookForward = Vector3.left;
                lookBackward = Vector3.right;
                lookLeft = Vector3.back;
                lookRight = Vector3.forward;
                break;
            case PlayerDirectionType.Right:
                lookForward = Vector3.right;
                lookBackward = Vector3.left;
                lookLeft = Vector3.forward;
                lookRight = Vector3.back;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Direziona l'abilità in base al pattern
    /// </summary>
    public void PatternDirection(DirectionType _direction)
    {
        switch (_direction)
        {
            case DirectionType.Forward:
                FindCells(lookForward);
                break;
            case DirectionType.Backward:
                FindCells(lookBackward);
                break;
            case DirectionType.Left:
                FindCells(lookLeft);
                break;
            case DirectionType.Right:
                FindCells(lookRight);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Funzione che controlla le celle in base alla direzione e al range del pattern
    /// </summary>    
    private void FindCells(Vector3 _direction)
    {   
        if(_direction.x != 0)
        {
            if(_direction.x > 0)
            {
                List<CellPrefScript> _cells = new List<CellPrefScript>();
                foreach (CellPrefScript _cell in grid.SendCells())
                {
                    if (_cell.z == PlayerPosZ && _cell.x > PlayerPosX && (_cell.x <= (PlayerPosX + Range)))
                    {
                        _cells.Add(_cell);
                    }
                }
                _cells.Sort((a, b) => a.x.CompareTo(b.x));
                CellsList.Add(_cells);
            }
            else if (_direction.x < 0)
            {
                List<CellPrefScript> _cells = new List<CellPrefScript>();
                foreach (CellPrefScript _cell in grid.SendCells())
                {
                    if (_cell.z == PlayerPosZ && _cell.x < PlayerPosX && (_cell.x >= (PlayerPosX - Range)))
                    {
                        _cells.Add(_cell);
                    }
                }
                _cells.Sort((a, b) => a.x.CompareTo(b.x));
                _cells.Reverse();
                CellsList.Add(_cells);
            }
        }
        else if(_direction.z != 0)
        {
            if (_direction.z > 0)
            {
                List<CellPrefScript> _cells = new List<CellPrefScript>();
                foreach (CellPrefScript _cell in grid.SendCells())
                {
                    if (_cell.x == PlayerPosX && _cell.z > PlayerPosZ && (_cell.z <= (PlayerPosZ + Range)))
                    {
                        _cells.Add(_cell);
                    }
                }
                _cells.Sort((a, b) => a.z.CompareTo(b.z));
                CellsList.Add(_cells);
            }
            else if (_direction.z < 0)
            {
                List<CellPrefScript> _cells = new List<CellPrefScript>();
                foreach (CellPrefScript _cell in grid.SendCells())
                {
                    if (_cell.x == PlayerPosX && _cell.z < PlayerPosZ && (_cell.z >= (PlayerPosZ - Range)))
                    {
                        _cells.Add(_cell);
                    }
                }                
                _cells.Sort((a, b) => a.z.CompareTo(b.z));
                _cells.Reverse();
                CellsList.Add(_cells);
            }
        }
    }

    /// <summary>
    /// Controlla le celle partendo dalla posizione del player e colorale se sono comprese tra il player e un ostacolo
    /// </summary>
    public void ColorPreview()
    {
        for (int i = 0; i < CellsList.Count; i++)
        {
            for (int j = 0; j < CellsList[i].Count; j++)
            {
                if (grid.CellFree(CellsList[i][j]))
                {
                    CellsList[i][j].MyCell.GetComponent<MeshRenderer>().material.color = Color.red;
                }
                else
                {
                    j = CellsList[i].Count;
                }
            }
        }
    }

    public void ClearList()
    {
        CellsList.Clear();
    }
}

public enum PlayerDirectionType
{
    Up,
    Down,
    Left,
    Right
}

public enum DirectionType
{
    Forward,
    Backward,
    Left,
    Right
}

