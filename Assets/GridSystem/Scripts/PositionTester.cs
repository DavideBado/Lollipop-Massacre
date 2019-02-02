using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;

public class PositionTester : MonoBehaviour {

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
        if(Input.GetKeyDown(KeyCode.W))
        {if( y<9)
            y++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (x > 0)
                x--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (y >0)
                y--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (x < 9)
                x++;
        }
    }
}
