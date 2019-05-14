using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;


public class PositionTester : MonoBehaviour
{
    public int x, y;

    public BaseGrid grid;

    public void GoToLeft() {
        x--;
        transform.position = grid.GetWorldPosition(x, y);
    }

    public void GoToRight() {
        x++;
        transform.position = grid.GetWorldPosition(x, y);
    }

    public void GoToUp() {
        y++;
        transform.position = grid.GetWorldPosition(x, y);
    }

    public void GoToDown() {
        y--;
        transform.position = grid.GetWorldPosition(x, y);
    }

}
