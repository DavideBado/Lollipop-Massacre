using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class PositionTester1 : MonoBehaviour {

    public int x;
    public int y;
   
    public BaseGrid grid;

    // Update is called once per frame
    void Update () {
        
        //CheckInput();

        if (grid)
        {
            transform.position = grid.GetWorldPosition(x, y);
        }
        
	}
   public void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {if( y<9)
            y++;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (x > 0)
                x--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (y >0)
                y--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (x < 9)
                x++;
        }
    }
}
