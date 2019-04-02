using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterPosition : MonoBehaviour
{
    GameManager manager;
    public Player1 P1;
    public Player2 P2;
    public SliderBehaviour _slider;
    
   
    void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        FindPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        FindPosition();      
    }

    public void FindPosition()
    {
        if (P1.MyTurn == true)
        {
            transform.position = (P1.transform.position + new Vector3(0, 2.5f, 0));
            //_slider.StartCounter(_slider.initialCountAmount);

        }

        else if (P2.MyTurn == true)
        {
            transform.position = (P2.transform.position + new Vector3(0, 2.5f, 0));
           // _slider.StartCounter(_slider.initialCountAmount);

        }
    }

    public void FindPlayers()
    {
        P1 = FindObjectOfType<Player1>();
        P2 = FindObjectOfType<Player2>();
    }
   
}
