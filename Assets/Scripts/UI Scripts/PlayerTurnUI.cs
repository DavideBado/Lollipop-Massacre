using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTurnUI : MonoBehaviour
{
    public List<Image> images = new List<Image>();
    OldGameManager GameManager;
    Image image;

    private void Start()
    {
        GameManager = FindObjectOfType<OldGameManager>();
        image = GetComponent<Image>();
    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.Timer > 0)
        {
            if (GameManager.Turn == true)
            {
                images[0].gameObject.SetActive(true); 
                images[1].gameObject.SetActive(false); 
            }
            else if (GameManager.Turn == false)
            {
                images[0].gameObject.SetActive(false);
                images[1].gameObject.SetActive(true);
            }
        }
        else
        {
            images[0].gameObject.SetActive(false);
            images[1].gameObject.SetActive(false);
        }
    }
}
