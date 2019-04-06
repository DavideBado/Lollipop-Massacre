using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseCanvas : MonoBehaviour
{
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
