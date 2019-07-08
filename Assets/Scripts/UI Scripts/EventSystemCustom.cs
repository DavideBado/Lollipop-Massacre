using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class EventSystemCustom : EventSystem
{
    public GameObject MainMenu;
    public ConfirmButton ConfirmButton;
    List<CharaSprites> m_characterSprites = new List<CharaSprites>();
    List<ButtonCustom1> m_Buttons = new List<ButtonCustom1>();
    public Sprite PlayTexture, BackTexture;
    CharaSprites currentCharaSprite;
    public TMP_Text m_AbilityDescription, m_AbilityName;
    public Image Preview, m_AbilityIcon;
    public string ChargeString, WhirlwindString;
    public int ID;
    public GameObject AlternativeSelected;
    protected override void OnEnable()
    {        
        base.OnEnable();
    }    

    protected override void Update()
    {
       
        SelectConfirm();
        m_characterSprites = FindObjectsOfType<CharaSprites>().ToList();
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
if(!currentSelectedGameObject.activeInHierarchy)
        {
            if (firstSelectedGameObject.activeInHierarchy)
            {
                SetSelectedGameObject(firstSelectedGameObject); 
            }
            else if (AlternativeSelected.activeInHierarchy)
            {
                SetSelectedGameObject(AlternativeSelected);
            }
        }
        
        if (currentSelectedGameObject == null)
        {
            SetSelectedGameObject(firstSelectedGameObject);
        }
        //Debug.Log(gameObject.name + currentSelectedGameObject.name);
        currentSelectedGameObject.GetComponent<MyEventSystemProvider>().eventSystem = this;
        
        if(ID == 1)
        {if (currentSelectedGameObject.GetComponent<CharaSprites>() != null)
            {
                currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
                currentCharaSprite.ArrowPOne.SetActive(true);
                Preview.sprite = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[3];
                m_AbilityIcon.sprite = currentCharaSprite.Character[0].GetComponent<Agent>().EnergySprites[2];
                m_AbilityDescription.text = currentCharaSprite.Character[0].GetComponent<Agent>().AbilityDescription.ToUpper();
                m_AbilityName.text = currentCharaSprite.Character[0].GetComponent<Agent>().AbilityName.ToUpper();              
            }
                    
        }
        else if (ID == 2)
        {
            if (currentSelectedGameObject.GetComponent<CharaSprites>() != null)
            {
                currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
                currentCharaSprite.ArrowPTwo.SetActive(true);
                Preview.sprite = currentCharaSprite.Character[1].GetComponent<Agent>()._Sprites[3];
                m_AbilityIcon.sprite = currentCharaSprite.Character[0].GetComponent<Agent>().EnergySprites[2];
                m_AbilityDescription.text = currentCharaSprite.Character[1].GetComponent<Agent>().AbilityDescription.ToUpper();
                m_AbilityName.text = currentCharaSprite.Character[1].GetComponent<Agent>().AbilityName.ToUpper();              
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
            //Debug.Log("Event:" + ID + " " + currentSelectedGameObject.name);

        foreach (CharaSprites _Sprite in m_characterSprites)
        {
            if(_Sprite.gameObject != currentSelectedGameObject)
            {
                if(ID == 1)
                {
                    _Sprite.ArrowPOne.SetActive(false);
                }
                else if (ID == 2)
                {
                    _Sprite.ArrowPTwo.SetActive(false);
                }
            }
        }
    }

    private void SelectConfirm()
    {
        if(PartyData.PartyCount(ID) == 3 && ConfirmButton != null && !MainMenu.activeSelf)
        {
            if(ID == 1)
            {
                currentCharaSprite.ArrowPOne.SetActive(false);
            }
            else if (ID == 2)
            {
                currentCharaSprite.ArrowPTwo.SetActive(false);
            }
            SetSelectedGameObject(ConfirmButton.gameObject);            
        }    
    }
   
    public void UpdateEventSystem(GameObject _button)
    {
        StartCoroutine(eventsCoroutine(_button));
    }

    IEnumerator eventsCoroutine(GameObject _button)
    {
        yield return 0;
        SetSelectedGameObject(null);
        SetSelectedGameObject(_button);
    }
}