﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;

public class PositionTesterOld : MonoBehaviour {
    Cell cell;
    public bool _Round, OnTheRoad = false;
    public int x, x2;
    public int y, y2;  
    public BaseGrid grid;
    int MaxAct;
    Collider BasicAtt;
    public Text Lifetext;
    public InputManagerCustom InputManager = new InputManagerCustom();
    public int PlayerID = 1;
    public GridConfigData configGrid;
    public GameObject respawn;
    

    private void Start()
    { // x2 && y2 Start = null, the next code lines change x2 && y2 != null
        x2 = x;
        y2 = y;
        BasicAtt = transform.GetChild(0).GetComponent<Collider>();
        InputManager.ManagerPlayerID = PlayerID;
        //transform.position = grid.GetWorldPosition(x, y) + new Vector3(0, 4);
        transform.position = respawn.transform.position;
    }
    // Update is called once per frame
    void Update () {
        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Round;
        Lifetext.text = "P1 Life:" + GetComponent<LifeManager>().Life.ToString(); // Life on screen

        if (_Round == false)
        {
            BasicAtt.enabled = false;
        }

        if (grid) // Check if we have a grid
        {
            cell = grid.GetCell(x, y);
            if (cell.Free == true) // Now if the cell is free
            { // Move the player && save x && y
                BasicAtt.enabled = false;

                transform.position = Vector3.MoveTowards(transform.position, grid.GetWorldPosition(x, y),
                GameObject.Find("GameManager").GetComponent<GameManager>().Speed * Time.deltaTime);
                if (transform.position == grid.GetWorldPosition(x, y))
                {

                    x2 = x;
                    y2 = y;
                    OnTheRoad = false;
                }
            }
            else // Load the old values of x && y
            {
                x = x2;
                y = y2;
            }
        }
    }

    public void Up() //Trasforma la chiamata del manager in una richiesta di movimento
    {
        if (y < (configGrid.DimY -1) && OnTheRoad == false && _Round == true)
        {
            y++;
            OnTheRoad = true;
        }
    }
    public void Left()
    {
        if (x > 0 && OnTheRoad == false && _Round == true)
        {
            x--;
            OnTheRoad = true;
        }
    }
    public void Down()
    {
        if (y > 0 && OnTheRoad == false && _Round == true)
        {
            y--;
            OnTheRoad = true;
        }
    }
    public void Right()
    {
        if (x < (configGrid.DimX - 1) && OnTheRoad == false && _Round == true)
        {
            x++;
            OnTheRoad = true;
        }
    }
    public void BasicAttack()
    { if (GameObject.Find("GameManager").GetComponent<GameManager>().CanAttack == true && _Round == true)
        {
            BasicAtt.enabled = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().CanAttack = false;
        }
    }

    //public bool checkIfPosEmpty() // This check if the cell is free
    //{
    //    GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("Player");
       

    //    foreach (GameObject current in allMovableThings)
    //    {
    //        if (current.transform.position == (grid.GetWorldPosition(x, y) + new Vector3(0, 4)))
    //            return false;
    //        else return true;
    //    }
    //    return true;
    //}
    //public bool checkIfPosEmptyWall()
    //{
    //    GameObject[] walls = GameObject.FindGameObjectsWithTag("Wall");

    //    foreach (GameObject current in walls)
    //    {
    //        if (current.transform.position == (grid.GetWorldPosition(x, y) + new Vector3(0, 5)))
    //            return false;
    //        else return true;
    //    }
    //    return true;
    //}
    //void Rotation()
    //{

    //    Vector3 lookAt = grid.GetWorldPosition(x, y);

    //    float AngleRad = Mathf.Atan2(lookAt.y - this.transform.position.y, lookAt.x - this.transform.position.x);

    //    float AngleDeg = (180 / Mathf.PI) * AngleRad;

    //    transform.rotation = Quaternion.Euler(0, AngleDeg, 0);
    //}

}
