using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : Button
{
    public EventSystem eventSystem;
    BaseEventData m_BaseEvent;
    GameObject SelectPOne, SelectPTwo;

    protected override void Start()
    {
        if (GetComponent<CharaSprites>() != null)
        {
            SelectPOne = GetComponent<CharaSprites>().ArrowPOne;
            SelectPTwo = GetComponent<CharaSprites>().ArrowPTwo;
        }
    }
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

    //public override void Select()
    //{
    //    if (eventSystem.alreadySelecting)
    //        return;
    //    Debug.Log(name);
    //    eventSystem.SetSelectedGameObject(gameObject);
    //}

    public override void OnSubmit(BaseEventData eventData)
    { //Output that the Button is in the submit stage
        int m_CharacterIndex = eventSystem.GetComponent<EventSystemCustom>().ID - 1;
        // Aggiungi alla lista e visualizza sprite grande nella preview del party --------> prima bisogna risolvere il bug del setactive con la lista in game

        if (PartyData.PartyCount(eventSystem.GetComponent<EventSystemCustom>().ID) < 3)
        {

            PartyData.AddToParty(eventSystem.GetComponent<EventSystemCustom>().ID, GetComponent<CharaSprites>().Character[m_CharacterIndex]);
        }

        Debug.Log(gameObject.name + " Submitted!" + eventSystem.gameObject.name);
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
        //Debug.Log(eventSystem);
        if(IsHighlighted(m_BaseEvent))
        {
            //if(eventSystem.GetComponent<EventSystemCustom>().ID == 1)
            //{
            //    SelectPOne.SetActive(true);
            //}
            //else
            //{
            //    SelectPOne.SetActive(false);
            //}
            //if (eventSystem.GetComponent<EventSystemCustom>().ID == 2)
            //{
            //    SelectPTwo.SetActive(true);
            //}
            //else
            //{
            //    SelectPTwo.SetActive(false);
            //}
        } else
        {
            SelectPOne.SetActive(false);
            SelectPTwo.SetActive(false);

        }
    }
}
