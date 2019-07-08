using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacter : MonoBehaviour
{
    public GameObject OldCanvas, NewCanvas;
    public GameObject Loading;
    public SelectMenu SelectMenu;
    

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (SelectMenu.ReadyPlayerOne == false)
            {
                FindObjectOfType<SelectMenu>().RemoveCharacter(1);
            }
            //else SelectMenu.ReadyPlayerOne = false;
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (SelectMenu.ReadyPlayerTwo == false)
            {
                FindObjectOfType<SelectMenu>().RemoveCharacter(2);
            }
            //else SelectMenu.ReadyPlayerTwo = false;
        }

        //if(Loading.activeInHierarchy == true && Input.GetKeyDown(KeyCode.A))
        //{
        //    GameObject Bottone = FindObjectOfType<OnClick>().gameObject;
        //    Bottone.GetComponent<OnClick>().LoadByIndex(1);
        //}

        if(Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.C))
        {
            NewCanvas.SetActive(false);           
            OldCanvas.SetActive(true);
        }
    }
}
