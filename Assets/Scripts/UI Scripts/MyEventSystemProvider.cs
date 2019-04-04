using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyEventSystemProvider : MonoBehaviour
{
    public EventSystem eventSystem;
    //List<EventSystem> events = new List<EventSystem>();

    //private void Start()
    //{
    //    events = FindObjectsOfType<EventSystem>().ToList();
    //    EventCheck();
    //}

    //private void Update()
    //{
    //    EventCheck();
    //}

    //void EventCheck()
    //{
    //    foreach (EventSystem _event in events)
    //    {
    //        if (_event.currentSelectedGameObject == gameObject)
    //        {
    //            eventSystem = _event;
    //        }
    //        else eventSystem = null;
    //    }
    //}
}