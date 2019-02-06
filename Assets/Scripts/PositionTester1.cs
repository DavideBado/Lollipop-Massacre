using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class PositionTester1 : MonoBehaviour {
    bool _Round;
    public int x, x2;
    public int y, y2;  
    public BaseGrid grid;
    int MaxAct;

    private void Start()
    { // x2 && y2 Start = null, the next code lines change x2 && y2 != null
        x2 = x;
        y2 = y;
    }
    // Update is called once per frame
    void Update () {
        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Round;
       
        if (grid) // Check if we have a grid
        {
            if (checkIfPosEmpty()) // Now if the cell is free
            { // Move the player && save x && y
                transform.position = grid.GetWorldPosition(x, y) + new Vector3(0, 4);
                x2 = x;
                y2 = y;
                GameObject.Find("GameManager").GetComponent<GameManager>().LessAct(); //Sottrai un azione
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
        if (y < 9 && _Round == false)
            y++;
    }
    public void Left()
    {
        if (x > 0 && _Round == false)
            x--;
    }
    public void Down()
    {
        if (y > 0 && _Round == false)
            y--;
    }
    public void Right()
    {
        if (x < 9 && _Round == false)
            x++;
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
