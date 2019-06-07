using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonCustomLoadingEnd : Button
{
    public EventSystem eventSystem;
    BaseEventData m_BaseEvent;
    Sprite m_StandardTexture;
    Vector2 m_StandardRect;
    Vector3 m_StandardPos;
    public delegate void OnSpriteChange();
    public OnSpriteChange OnChangeCharacter;
    public GameObject Game;

    protected override void Start()
    {
        m_StandardPos = transform.position;
        m_StandardTexture = GetComponent<Image>().sprite;
        m_StandardRect = GetComponent<RectTransform>().rect.size;
    }       

    public override void OnSubmit(BaseEventData eventData)
    {

        if (GetComponent<OnSelectData>().GameProps != null)
        {
            GetComponent<OnSelectData>().EventSystemP1.gameObject.SetActive(false);
            GetComponent<OnSelectData>().EventSystemP2.gameObject.SetActive(false);
            GetComponent<OnSelectData>().GameProps.SetActive(true);
            GetComponent<OnSelectData>().NextCanvas.SetActive(true);
            GetComponent<OnSelectData>().ThisCanvas.SetActive(false);
        }
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

