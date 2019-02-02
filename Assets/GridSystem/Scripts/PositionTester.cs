using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class PositionTester : MonoBehaviour {

    public int x, x2;
    public int y, y2;   
    public BaseGrid grid;
    private void Start()
    {
        x2 = x;
        y2 = y;
    }
    // Update is called once per frame
    void Update () {
        //CheckInput();
        if (grid)
        {
            if (checkIfPosEmpty())
            {
                transform.position = grid.GetWorldPosition(x, y) + new Vector3(0, 4);
                x2 = x;
                y2 = y;
            }
            else
            {               
                x = x2;
                y = y2;
            }
        }

    }
    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (y < 9)
                y++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (x > 0)
                x--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (y > 0)
                y--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (x < 9)
                x++;
        }
    }
    public bool checkIfPosEmpty()
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("Movable");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position == grid.GetWorldPosition(x, y))
                return false;
        }
        return true;
    }
}
