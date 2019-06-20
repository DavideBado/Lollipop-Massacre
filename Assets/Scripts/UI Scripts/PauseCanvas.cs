using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseCanvas : MonoBehaviour
{
    GameManager manager;

    private void OnEnable()
    {
        GetComponent<OnSelectData>().panelBase.SetActive(true);
        GetComponent<OnSelectData>().PanelActive.SetActive(false);
    }

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();


    }
    private void OnDisable()
    {

        manager.MyPause();
    }

}
