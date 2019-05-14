using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    OldGameManager manager;

    private void Start()
    {
        manager = FindObjectOfType<OldGameManager>();
    }
    private void OnDisable()
    {

        manager.MyPause();
    }
}
