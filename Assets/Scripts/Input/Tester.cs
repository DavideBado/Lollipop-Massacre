using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class Tester : MonoBehaviour
{
    InputSimulator m_InputSimulator = new InputSimulator();


    // Update is called once per frame
    void Update()
    {
        m_InputSimulator.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.RETURN);

        if(Input.GetKey(KeyCode.Return))
        {
            Debug.Log("Funziona!!!");
        }
    }
}
