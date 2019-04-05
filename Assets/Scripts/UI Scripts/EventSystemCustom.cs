using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemCustom : EventSystem
{
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
        if (currentSelectedGameObject == null)
        {
            SetSelectedGameObject(firstSelectedGameObject);
        }
        Debug.Log(gameObject.name + currentSelectedGameObject.name);
        currentSelectedGameObject.GetComponent<MyEventSystemProvider>().eventSystem = this;
        
        if(ID == 1)
        {
            currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
            currentCharaSprite.ArrowPOne.SetActive(true);
            Preview.texture = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[2];
        }
        else if (ID == 2)
        {
            currentCharaSprite = currentSelectedGameObject.GetComponent<CharaSprites>();
            currentCharaSprite.ArrowPTwo.SetActive(true);
            Preview.texture = currentCharaSprite.Character[0].GetComponent<Agent>()._Sprites[3];
        }
    }

  
}