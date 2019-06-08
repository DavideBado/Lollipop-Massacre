using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConfirmButton : Button
{
    public EventSystem eventSystem;
    BaseEventData m_BaseEvent;
    GameObject SelectPOne, SelectPTwo;
    List<EventSystemCustom> eventSystemCustoms = new List<EventSystemCustom>();

    protected override void Start()
    {
        GetComponent<OnSelectData>().OnSelectImage.enabled = true;
        eventSystemCustoms = FindObjectsOfType<EventSystemCustom>().ToList();       
    }

    public override void OnSubmit(BaseEventData eventData)
    { //Output that the Button is in the submit stage
        GetComponent<OnSelectData>().OnSelectImage.enabled = false;
        if (eventData.currentInputModule.GetComponent<EventSystemCustom>().ID == 1)
        {
            GetComponent<OnSelectData>().SelectMenu.ReadyPlayerOne = true;
        }
        else if (eventData.currentInputModule.GetComponent<EventSystemCustom>().ID == 2)
        {
            GetComponent<OnSelectData>().SelectMenu.ReadyPlayerTwo = true;
        }
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
    }    
}
