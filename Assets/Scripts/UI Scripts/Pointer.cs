using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pointer : MonoBehaviour
{
    public GameObject PointerImage;
    GameManager manager;
    public Player1 P1;
    public Player2 P2;
    public List<Sprite> sprites = new List<Sprite>();
    bool pointerOn = true;
    private void Start()
    {
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayers();
        FindPosition();
    }

    public void FindPosition()
    {
        if (manager.TimerOn == true && pointerOn == true)
        {
            PointerImage.GetComponent<Image>().enabled = true;
            if (P1.MyTurn == true)
            {
                PointerImage.transform.position = (P1.transform.position + new Vector3(0, 2.5f + Mathf.PingPong(Time.time, 0.5f)));
                PointerImage.GetComponent<Image>().sprite = sprites[0];
            }

            else if (P2.MyTurn == true)
            {
                PointerImage.transform.position = (P2.transform.position + new Vector3(0, 2.5f + Mathf.PingPong(Time.time, 0.5f)));
                PointerImage.GetComponent<Image>().sprite = sprites[1];
            }
        }
        else
        {
            if (manager.TimerOn == false)
                pointerOn = true;
            PointerImage.GetComponent<Image>().enabled = false;
        }
    }

    public void PointerOff()
    {
        pointerOn = false;
    }

    void FindPlayers()
    {
        P1 = FindObjectOfType<Player1>();
        P2 = FindObjectOfType<Player2>();
    }
}
