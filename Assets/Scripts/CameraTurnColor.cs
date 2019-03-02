using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTurnColor : MonoBehaviour

{

    public Color color1 = Color.blue;
    public Color color2 = Color.red;
    public Camera cam;
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.clearFlags = CameraClearFlags.SolidColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.Round == true)
        {
            cam.backgroundColor = color1;
        }
        else if(gm.Round == false)
        {
            cam.backgroundColor = color2;
        }
    }
}
