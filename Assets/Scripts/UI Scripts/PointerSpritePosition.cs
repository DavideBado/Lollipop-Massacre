using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerSpritePosition : MonoBehaviour
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
        FindPlayers();
        FindPosition();
    }

    public void FindPosition()
    {
        if (P1.MyTurn == false)
        {
            transform.position = (P1.transform.position + new Vector3(0, 2.5f, 0));
            GetComponent<RawImage>().texture = P1.GetComponent<Agent>()._Sprites[2];

        }

        else if (P2.MyTurn == false)
        {
            transform.position = (P2.transform.position + new Vector3(0, 2.5f, 0));
            GetComponent<RawImage>().texture = P2.GetComponent<Agent>()._Sprites[2];

        }
    }

    public void FindPlayers()
    {
        P1 = FindObjectOfType<Player1>();
        P2 = FindObjectOfType<Player2>();
    }

}