using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class SliderBehaviour : MonoBehaviour
{
    private Sequence sequenceTimer;
    private Sequence sequenceFill;
    public Image fillImage;
    public TMPro.TextMeshProUGUI counterText;
    public bool Loop = false;
    public bool StartOnAwake = false;
    [SerializeField] private float countAmount = 5f;
    float m_StopFill;
    public Color RingColor;

    public delegate void TimerDelegate();

    public TimerDelegate StartTimer;
    public TimerDelegate EndTimer;
    GameManager manager;
    public float endValue = 0;


    public void Start()
    {
        m_StopFill = countAmount;
        fillImage.color = RingColor;
        manager = FindObjectOfType<GameManager>();
        if (StartOnAwake)
            StartCounter();

        if (Loop)
            StartCounter();

    }

   

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A)) {
        //    StartCounter(countAmount);
        //}

        counterText.text = ((int)countAmount + 1).ToString();

        if (manager.TimerOn == false)
        {

            m_StopFill = -100000;
            sequenceTimer.Pause();
        }
        else
        {
            m_StopFill = countAmount;
            sequenceTimer.Play();
           


        }
    }

    float initialCountAmount = 5f;

    public void StartCounter() {


           fillImage.DOFillAmount(0, 1 / countAmount)
           .SetSpeedBased(true)
           .SetEase(Ease.Linear);


          sequenceTimer = DOTween.Sequence().Append(DOTween.To(() => countAmount, x => countAmount = x, endValue, countAmount)
            .SetEase(Ease.Linear)
            .OnComplete(timerCompleted));   
       
        
        
    }

    public void timerCompleted() {
        fillImage.DOFillAmount(1, 0);
        countAmount = initialCountAmount;
       
        if (EndTimer != null)
            EndTimer();
        if (Loop)
        {
            StartCounter();
        }
    }

    
}
