using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class EventSystemCustom : EventSystem
{    
    public ConfirmButton ConfirmButton;
    List<CharaSprites> m_characterSprites = new List<CharaSprites>();
    List<ButtonCustom1> m_Buttons = new List<ButtonCustom1>();
    public Sprite PlayTexture, BackTexture;
    CharaSprites currentCharaSprite;
    public TMP_Text _Text;
    public Image Preview;
    public string ChargeString, WhirlwindString;
    public int ID;
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
        else if(currentSelectedGameObject.activeInHierarchy == false && firstSelectedGameObject.activeInHierarchy == true)
        {
            SetSelectedGameObject(firstSelectedGameObject);
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
                if(currentCharaSprite.Character[0].GetComponent<Charge>() != null)
                {
                    _Text.text = ChargeString.ToUpper();
                }
                else if (currentCharaSprite.Character[0].GetComponent<Whirlwind>() != null)
                {

                    _Text.text = WhirlwindString.ToUpper();
                }
                else
                {
                    _Text.text = "";
                }
            }
                    
        }
        else if (ID == 2)
        {
            if (currentSelectedGameObject.GetComponent<CharaSprites>() != null)
            {
                currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
                currentCharaSprite.ArrowPTwo.SetActive(true);
                Preview.sprite = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[4];
                if (currentCharaSprite.Character[0].GetComponent<Charge>() != null)
                {
                    _Text.text = ChargeString.ToUpper();
                }
                else if (currentCharaSprite.Character[0].GetComponent<Whirlwind>() != null)
                {
                    _Text.text = WhirlwindString.ToUpper();
                }
                else
                {
                    _Text.text = "";
                }
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
        if(PartyData.PartyCount(ID) == 3 && ConfirmButton != null)
        {
            SetSelectedGameObject(ConfirmButton.gameObject);            
        }
    
    }
  
}