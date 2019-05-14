using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{

    public KeyCode UpButton;
    public KeyCode DownButton;
    public KeyCode LeftButton;
    public KeyCode RightButton;

    // Update is called once per frame
    void Update()
    {
        if (UnityEngine.Input.GetKeyDown(LeftButton)) {
            // left
            SendMessage("GoToLeft");
        }
        if (UnityEngine.Input.GetKeyDown(RightButton)) {
            // right
            SendMessage("GoToRight");
        }
        if (UnityEngine.Input.GetKeyDown(UpButton)) {
            // up
            SendMessage("GoToUp");
        }
        if (UnityEngine.Input.GetKeyDown(DownButton)) {
            // down
            SendMessage("GoToDown");
        }
    }
}
