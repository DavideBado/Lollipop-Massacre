using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    public TMP_Text TimerText;
    public GameManager GameManager;
    // Update is called once per frame
    void Update()
    {
        if(GameManager.TimerOn == true)
            TimerText.text = ((int)GameManager.Timer).ToString();
        else
        {
            TimerText.text = 5.ToString();
        }
    }
}
