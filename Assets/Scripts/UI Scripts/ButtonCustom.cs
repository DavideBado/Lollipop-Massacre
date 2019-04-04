using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : Button
{
    public EventSystem eventSystem;



    //public override void OnPointerDown(PointerEventData eventData)
    //{
    //    if (eventData.button != PointerEventData.InputButton.Left)
    //        return;

    //    // Selection tracking
    //    if (IsInteractable() && navigation.mode != Navigation.Mode.None)
    //        eventSystem.SetSelectedGameObject(gameObject, eventData);
    //    {
    //        //base.OnPointerDown(eventData);
    //        OnSubmit(eventData);
           
    //        Debug.Log(eventSystem.gameObject.name);
    //    }
    //}

    public override void Select()
    {
        if (eventSystem.alreadySelecting)
            return;

        eventSystem.SetSelectedGameObject(gameObject);
    }

    public override void OnSubmit(BaseEventData eventData)
    {
        //Output that the Button is in the submit stage
        Debug.Log(gameObject.name + " Submitted!" + eventSystem.gameObject.name);
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
        Debug.Log(eventSystem);
    }
}
