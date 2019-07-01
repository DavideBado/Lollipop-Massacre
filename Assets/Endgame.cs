using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endgame : MonoBehaviour
{
    public EventSystemCustom eventsys;

    public void OnEnable()
    {
        eventsys = FindObjectOfType<EventSystemCustom>();
        eventsys.UpdateEventSystem(FindObjectOfType<RematchButton>().gameObject);
    }
}
