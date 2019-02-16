using System.Collections;
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
    public Collider ColliderBasicAtt;
    public Text Lifetext;
    public GameObject respawn;
    public GridConfigData configGrid;

    private void Start()
    { // x2 && y2 Start = null, the next code lines change x2 && y2 != null
        x2 = x;
        y2 = y;
        //BasicAtt = transform.GetChild(0).GetComponent<Collider>();
        transform.position = respawn.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        _Round = GameObject.Find("GameManager").GetComponent<GameManager>().Round;

        Lifetext.text = "P2 Life:" + GetComponent<LifeManager>().Life.ToString(); // Life on screen

        if (_Round == true)
        {

            ColliderBasicAtt.enabled = false;
        }

       
        if (grid) // Check if we have a grid
        {
           
            if (checkIfPosEmpty()) // Now if the cell is free
            { // Move the player && save x && y
                ColliderBasicAtt.enabled = false;

              
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
        if (y < (configGrid.DimY - 1) && OnTheRoad == false && _Round == false)
        {
            y++;
            OnTheRoad = true;
        }
    }
    public void Left()
    {
        if (x > 0 && OnTheRoad == false && _Round == false)
        {
            x--;
            OnTheRoad = true;
        }
    }
    public void Down()
    {
        if (y > 0 && OnTheRoad == false && _Round == false)
        {
            y--;
            OnTheRoad = true;
        }
    }
    public void Right()
    {
        if (x < (configGrid.DimX - 1) && OnTheRoad == false && _Round == false)
        {
            x++;
            OnTheRoad = true;
        }
    }
    public void BasicAttack()
    {
       
        if (_Round == false)
        {
            ColliderBasicAtt.enabled = true;
            Debug.Log("Messaggio Arrivato P2");
        }
        else ColliderBasicAtt.enabled = false;
    }

    public bool checkIfPosEmpty() // This check if the cell is free
    {
        GameObject[] allMovableThings = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject current in allMovableThings)
        {
            if (current.transform.position == (grid.GetWorldPosition(x, y) + new Vector3(0, 4)))
                return false;
        }
        return true;
    }
   
}
