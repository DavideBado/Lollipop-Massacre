using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GridSystem;
using UnityEngine.UI;
using System.Linq;

public class Player2 : Agent
{

   

    private void Update()
    {
        TextUpdate();
        Sicura();
        InUpdate();
    }

   

    void TextUpdate()
    {
        Lifetext.text = "P2 Life:" + GetComponent<LifeManager>().Life.ToString(); // Life on screen

    }

    void Sicura()
    {
        if (_Round == true) // Se non è il tuo turno
        {
            BasicAtt.enabled = false; // Metti via le armi
        }
    }

    #region Input

    public void Up() //Trasforma la chiamata del manager in una richiesta di movimento
    {
        if (y < (configGrid.DimY - 1) && OnTheRoad == false && _Round == false)
        {
            RotDown = false; RotLeft = false; RotRight = false;
            OnTheRoad = true;
            y++;
            Rotation();
            if (RotUp == false)
            {
                y--;
                RotUp = true;
            }
        }
    }
    public void Left()
    {
        if (x > 0 && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotDown = false; RotRight = false;
            OnTheRoad = true;
            x--;
            Rotation();
            if (RotLeft == false)
            {
                x++;
                RotLeft = true;
            }
        }
    }
    public void Down()
    {
        if (y > 0 && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotLeft = false; RotRight = false;
            OnTheRoad = true;
            y--;
            Rotation();
            if (RotDown == false)
            {
                y++;
                RotDown = true;
            }
        }
    }
    public void Right()
    {
        if (x < (configGrid.DimX - 1) && OnTheRoad == false && _Round == false)
        {
            RotUp = false; RotDown = false; RotLeft = false;
            OnTheRoad = true;
            x++;
            Rotation();
            if (RotRight == false)
            {
                x--;
                RotRight = true;
            }
        }
    }

    public void BasicAttack()
    {
        if (_Round == false) // Se è il mio turno
        {
            BasicAtt.enabled = true; // Attiva il collider di attacco
        }
        else BasicAtt.enabled = false;
    }

#endregion
    
}
