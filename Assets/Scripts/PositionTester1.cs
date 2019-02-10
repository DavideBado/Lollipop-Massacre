﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;

public class PositionTester1 : MonoBehaviour {
    bool _Round, OnTheRoad = false;
    public int x, x2;
    public int y, y2;  
    public BaseGrid grid;
    int MaxAct;
    Collider BasicAtt;
    public Text Lifetext;
    public int playerID = 2;
    public InputManagerCustom InputManager = new InputManagerCustom();

    private void Start()
     
    { // x2 && y2 Start = null, the next code lines change x2 && y2 != null
        x2 = x;
        y2 = y;
        BasicAtt = transform.GetChild(0).GetComponent<Collider>();
        InputManager.ManagerPlayerID = playerID;
        transform.position = grid.GetWorldPosition(x, y) + new Vector3(0, 4);
    }
    // Update is called once per frame
    void Update () {

        Lifetext.text = "P2 Life:" + GetComponent<LifeManager>().Life.ToString(); // Life on screen

        if (_Round == false)
        {
            BasicAtt.enabled = false;
        }

        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Round;
       
        if (grid) // Check if we have a grid
        {
            if (checkIfPosEmpty()) // Now if the cell is free
            { // Move the player && save x && y
                BasicAtt.enabled = false;
                transform.position = Vector3.MoveTowards(transform.position, grid.GetWorldPosition(x, y) + new Vector3(0, 4),
               GameObject.Find("GameManager").GetComponent<GameManager>().Speed * Time.deltaTime);
                if (transform.position == grid.GetWorldPosition(x, y) + new Vector3(0, 4))
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
        if (OnTheRoad == false && _Round == false)
        {
            y++;
            OnTheRoad = true;
        }
    }
    public void Left()
    {
        if (OnTheRoad == false && _Round == false)
        {
            x--;
            OnTheRoad = true;
        }
    }
    public void Down()
    {
        if (OnTheRoad == false && _Round == false)
        {
            y--;
            OnTheRoad = true;
        }
    }
    public void Right()
    {
        if (OnTheRoad == false && _Round == false)
        {
            x++;
            OnTheRoad = true;
        }
    }
    public void BasicAttack()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager>().CanAttack == true && _Round == false)
        {
            BasicAtt.enabled = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().CanAttack = false;
        }
    }

    public bool checkIfPosEmpty() // This check if the cell is free
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("Movable");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position == (grid.GetWorldPosition(x, y) + new Vector3(0, 4)))
                return false;
        }
        return true;
    }
   
}
