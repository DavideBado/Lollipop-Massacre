using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSubscriberTest01 : MonoBehaviour
{
    public SliderBehaviour slider;

    private void OnEnable() {
        slider.EndTimer += endTimerDelegate;
       
    }

    private void endTimerDelegate() {
        Debug.Log("Timer terminato");
    }

    private void startTimerDelegate()
    {
        Debug.Log("TimerPartito");

    }
    private void OnDisable() {
        slider.EndTimer -= endTimerDelegate;
        
    }

}
