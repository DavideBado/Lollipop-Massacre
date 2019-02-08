using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class GamePadInputManager
{

    #region Axis
    public static float MainHorizontal()
    {
        float r = 0f;
        r += Input.GetAxis("GP_MainHorizontal");  // le string degli input fanno riferimento all'editor di unity

        return Mathf.Clamp(r, -1.0f, 1.0f);
       
     
    }

    public static float MainVertical()
    {
        float r = 0f;
        r += Input.GetAxis("GP_MainVertical");

        return Mathf.Clamp(r, -1.0f, 1.0f);
    }

    public static Vector3 MainGamePad()
    {
        return new Vector3(MainHorizontal(), 0, MainVertical());
    }

    #endregion Axis

    #region Buttons

    public static bool CrossButton()
    {
        return Input.GetButtonDown("CrossButton");
    }

    #endregion Buttons

}
