using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustom1 : Button
{
    public EventSystem eventSystem;
    BaseEventData m_BaseEvent;
    Sprite m_StandardTexture;
    Vector2 m_StandardRect;

    protected override void Start()
    {
        m_StandardTexture = GetComponent<Image>().sprite;
        m_StandardRect = GetComponent<RectTransform>().rect.size;
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
    {
        //Output that the Button is in the submit stage
        Debug.Log(gameObject.name + " Submitted!" + eventSystem.gameObject.name);
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
        Debug.Log(eventSystem);
        if (IsHighlighted(m_BaseEvent))
        {
            GetComponent<Image>().sprite = GetComponent<OnSelectData>().OnSelectImage.sprite;
            GetComponent<RectTransform>().sizeDelta = GetComponent<OnSelectData>().OnSelectDim.rect.size;
        }
        else
        {
            GetComponent<Image>().sprite = m_StandardTexture;
            GetComponent<RectTransform>().sizeDelta = m_StandardRect;
        }
    }
}
