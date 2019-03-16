﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SliderBehaviour : MonoBehaviour
{
    public Image fillImage;
    public TMPro.TextMeshProUGUI counterText;
    public bool Loop = false;
    public bool StartOnAwake = false;
    [SerializeField] private float countAmount = 5f;
    public Color RingColor;

    public delegate void TimerDelegate();

    public TimerDelegate StartTimer;
    public TimerDelegate EndTimer;

    public void Start() {
        if (StartOnAwake)
            StartCounter(countAmount);

        if (Loop)
            StartCounter(countAmount);

        fillImage.color = RingColor;
    }

   

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) {
        //    StartCounter(countAmount);
        //}

        counterText.text = ((int)countAmount + 1).ToString();
        Debug.Log(countAmount);
    }

    public float initialCountAmount;

    public void StartCounter(float time) {
        initialCountAmount = time;

        fillImage.DOFillAmount(0, 1 / countAmount)
            .SetSpeedBased(true)
            .SetEase(Ease.Linear);
            

        DOTween.To(() => countAmount, x => countAmount = x, 0, countAmount)
            .SetEase(Ease.Linear)
            .OnComplete(timerCompleted);
    }

    public void timerCompleted() {
        fillImage.DOFillAmount(1, 0);
        countAmount = initialCountAmount;
        if(EndTimer != null)
            EndTimer();
        if (Loop) {
            StartCounter(countAmount);
        }
    }

    
}
