using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public class EventSystemCustom : EventSystem
{
    List<ButtonCustom1> m_Buttons = new List<ButtonCustom1>();
    public Sprite PlayTexture, BackTexture;
    CharaSprites currentCharaSprite;
    public RawImage Preview;
    public int ID;
    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void Update()
    {
        EventSystem originalCurrent = EventSystem.current;
        current = this;
        base.Update();
        current = originalCurrent;

        if (firstSelectedGameObject.activeInHierarchy == false || currentSelectedGameObject == null || firstSelectedGameObject == null)
        {
            m_Buttons = FindObjectsOfType<ButtonCustom1>().ToList();
            if(m_Buttons.Count > 0)
            {
                SetSelectedGameObject(m_Buttons[0].gameObject);
            }
        }
        else if(currentSelectedGameObject.activeInHierarchy == false && firstSelectedGameObject.activeInHierarchy == true)
        {
            SetSelectedGameObject(firstSelectedGameObject);
        }
        if (currentSelectedGameObject == null)
        {
            SetSelectedGameObject(firstSelectedGameObject);
        }
        Debug.Log(gameObject.name + currentSelectedGameObject.name);
        currentSelectedGameObject.GetComponent<MyEventSystemProvider>().eventSystem = this;
        
        if(ID == 1)
        {if (currentSelectedGameObject.GetComponent<CharaSprites>() != null)
            {
                currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
                currentCharaSprite.ArrowPOne.SetActive(true);
                Preview.texture = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[2];
            }
        }
        else if (ID == 2)
        {
            if (currentSelectedGameObject.GetComponent<CharaSprites>() != null)
            {
                currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
                currentCharaSprite.ArrowPTwo.SetActive(true);
                Preview.texture = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[3];
            }
            //else if(currentSelectedGameObject.name == "Play")
            //{
            //    currentSelectedGameObject.GetComponent<Image>().sprite = PlayTexture;
            //}
            //else if (currentSelectedGameObject.name == "Back")
            //{
            //    currentSelectedGameObject.GetComponent<Image>().sprite = BackTexture;
            //}
        }
    }

  
}