using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    GameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }
    private void OnDisable()
    {

        manager.MyPause();
    }
}
