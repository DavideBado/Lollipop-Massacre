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
    private CharaSprites m_characterSprite;
    
    protected override void Start()
    {
        eventSystemCustoms = FindObjectsOfType<EventSystemCustom>().ToList();
        m_characterSprite = GetComponent<CharaSprites>();
        if (m_characterSprite != null)
        {
            SelectPOne = GetComponent<CharaSprites>().ArrowPOne;
            SelectPTwo = GetComponent<CharaSprites>().ArrowPTwo;
        }
    }

    public override void OnSelect(BaseEventData eventData)
    {
        if(m_characterSprite != null)
        {
            int ID = eventData.currentInputModule.GetComponent<EventSystemCustom>().ID;
            if (ID > 0)
            {
                m_characterSprite.BigCharaSprites[(ID - 1)][(PartyData.PartyCount(ID))].sprite = m_characterSprite.Character[(ID - 1)].GetComponent<Agent>()._Sprites[1];
                m_characterSprite.BigCharaSprites[(ID - 1)][(PartyData.PartyCount(ID))].gameObject.SetActive(true);
            }
        }
    }

    public override void OnSubmit(BaseEventData eventData)
    { //Output that the Button is in the submit stage
        int m_CharacterIndex = eventData.currentInputModule.GetComponent<EventSystemCustom>().ID - 1;
        
        // Aggiungi alla lista e visualizza sprite grande nella preview del party --------> prima bisogna risolvere il bug del setactive con la lista in game

        if (PartyData.PartyCount(eventData.currentInputModule.GetComponent<EventSystemCustom>().ID) < 3)
        {
            if (PartyCheck(eventData.currentInputModule.GetComponent<EventSystemCustom>().ID))
            {
                PartyData.AddToParty(eventData.currentInputModule.GetComponent<EventSystemCustom>().ID, GetComponent<CharaSprites>().Character[m_CharacterIndex]);
            }
        }

        //Debug.Log(gameObject.name + " Submitted!" + eventData.currentInputModule.GetComponent<EventSystemCustom>().gameObject.name);
    }

    private void Update()
    {
        eventSystem = GetComponent<MyEventSystemProvider>().eventSystem;

    }

    bool PartyCheck(int _PlayerID)
    {
        if(_PlayerID == 1)
        {
            foreach (GameObject _Object in PartyData.POnePart)
            {
                if (_Object == GetComponent<CharaSprites>().Character[(_PlayerID - 1)])
                {
                    return false;
                }
               
            }
        }
        else if (_PlayerID == 2)
        {
            foreach (GameObject _Object in PartyData.PTwoPart)
            {
                if (_Object == GetComponent<CharaSprites>().Character[(_PlayerID - 1)])
                {
                    return false;
                }
       
            }
        }
        return true;
    }
    
}
