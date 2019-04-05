using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemCustom : EventSystem
{
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