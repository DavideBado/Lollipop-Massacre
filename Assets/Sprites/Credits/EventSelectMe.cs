using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSelectMe : MonoBehaviour
{
    public EventSystemCustom EventSystem;

    private void OnEnable()
    {
        EventSystem.UpdateEventSystem(gameObject);
    }
}
