using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom : Button
{
    public EventSystem eventSystem;
    BaseEventData m_BaseEvent;
    GameObject SelectPOne, SelectPTwo;
    List<EventSystemCustom> eventSystemCustoms = new List<EventSystemCustom>();

    protected override void Start()
    {
        eventSystemCustoms = FindObjectsOfType<EventSystemCustom>().ToList();
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

    }
}
