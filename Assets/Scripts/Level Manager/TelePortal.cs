using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TelePortal : MonoBehaviour
{
    Collider characterCollider;
    public GameObject MyArea;
    TelePortal otherteleport;
    public int ID;
    bool canTeleport;


    private void OnEnable()
    {

       // gameManager.ActivatePortal += TeleportCheck;
    }
    private void OnDisable()
    {
       // gameManager.ActivatePortal -= TeleportCheck;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Agent>() != null)
        {
            characterCollider = other;
        }
    }

    private void TeleportNow(Collider other)
    {       
        if (other.GetComponent<Agent>().MyTurn == true)
        {
            other.GetComponent<Agent>().x = (int)otherteleport.transform.position.x;
            other.GetComponent<Agent>().x2 = (int)otherteleport.transform.position.x;
            other.GetComponent<Agent>().y = (int)otherteleport.transform.position.z;
            other.GetComponent<Agent>().y2 = (int)otherteleport.transform.position.z;
            other.transform.position = otherteleport.transform.position;            
        }
    }

    void TeleportCheck()
    {
       if(characterCollider != null)
        {
            TeleportNow(characterCollider);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        characterCollider = null;
    }

    //// Update is called once per frame
    void Update()
    {
        FindPortal();
    }

    void FindPortal()
    {
        if(otherteleport == null)
        {
            List<TelePortal> _portalList = FindObjectsOfType<TelePortal>().ToList();
            foreach (TelePortal _portal in _portalList)
            {
                if (_portal != this)
                {
                    otherteleport = _portal;
                } 
            }
        }
    }
    void Move()
    {
    //    if (Input.GetKey(KeyCode.M))
    //    {
    //        FindObjectOfType<GameManager>().Pause = true;
    //        if (ID == 1)
    //        {

    //            if (Input.GetKeyDown(KeyCode.W))
    //            {
    //                transform.Translate(Vector3.forward);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.S))
    //            {
    //                transform.Translate(Vector3.back);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.A))
    //            {
    //                transform.Translate(Vector3.left);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.D))
    //            {
    //                transform.Translate(Vector3.right);
    //            }
    //        }

    //        if (ID == 2)
    //        {

    //            if (Input.GetKeyDown(KeyCode.UpArrow))
    //            {
    //                transform.Translate(Vector3.forward);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.DownArrow))
    //            {
    //                transform.Translate(Vector3.back);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //            {
    //                transform.Translate(Vector3.left);
    //            }
    //            else if (Input.GetKeyDown(KeyCode.RightArrow))
    //            {
    //                transform.Translate(Vector3.right);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        FindObjectOfType<GameManager>().Pause = false;
    //    }
    }
}
