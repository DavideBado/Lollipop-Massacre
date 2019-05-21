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
    Vector3 m_StandardPos;
    public delegate void OnSpriteChange();
    public OnSpriteChange OnChangeCharacter;


    protected override void Start()
    {
        m_StandardPos = transform.position;
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
        
        if(GetComponent<OnSelectData>().NextCanvas != null && GetComponent<OnSelectData>().NextCanvas.tag != "Loading")
        {
            GetComponent<OnSelectData>().NextCanvas.SetActive(true);
        }
        else if (GetComponent<OnSelectData>().NextCanvas != null && GetComponent<OnSelectData>().NextCanvas.tag == "Loading" && PartyData.POnePart.Count == 3 && PartyData.PTwoPart.Count == 3)
        {
            GetComponent<OnSelectData>().NextCanvas.SetActive(true);
        }
        else if (GetComponent<OnClick>() != null)
        {
            GetComponent<OnClick>().LoadByIndex(GetComponent<OnSelectData>().SceneIndex);
        }
        else if(GetComponentInParent<PauseCanvas>() != null)
        {
            GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
        }

        if (GetComponent<OnSelectData>().NextCanvas != null && GetComponent<OnSelectData>().NextCanvas.tag != "Loading")
        {
            GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
        }
        else if (GetComponent<OnSelectData>().NextCanvas != null && GetComponent<OnSelectData>().NextCanvas.tag == "Loading" && PartyData.POnePart.Count == 3 && PartyData.PTwoPart.Count == 3)
        {
            GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
        }
        //Debug.Log(gameObject.name + " Submitted!" + eventSystem.gameObject.name);
        //OnChangeCharacter();
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;
        //Debug.Log(eventSystem);
        if (IsHighlighted(m_BaseEvent))
        {
            if(GetComponent<OnSelectData>().OnSelectImage.sprite != null)

    {
                GetComponent<Image>().sprite = GetComponent<OnSelectData>().OnSelectImage.sprite; 
            }
            if (GetComponent<OnSelectData>().OnSelectDim != null)
            {
                GetComponent<RectTransform>().sizeDelta = GetComponent<OnSelectData>().OnSelectDim.rect.size; 
            }
            if (GetComponent<OnSelectData>().Data_Transform != null)
            {
                transform.position = GetComponent<OnSelectData>().Data_Transform.position; 
            }
        }
        else
        { 
            transform.position = m_StandardPos;
            GetComponent<Image>().sprite = m_StandardTexture;
            GetComponent<RectTransform>().sizeDelta = m_StandardRect;
        }
    }
}

