using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public EventSystemCustom EventSystemP1;
    public GameObject FirstButton, PrevPanel;
    private void OnEnable()
    {
        EventSystemP1.UpdateEventSystem(FirstButton);
    }   
}
